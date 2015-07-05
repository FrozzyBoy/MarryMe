namespace MarryMe.Model
{
	#region Using

	using System;
	using System.Text.RegularExpressions;
	using System.Threading;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Factory;
	using MarryMe.Model.Interfaces;

	#endregion

	public class CommonController : ICommonController
	{

		#region Constants

		private const string StoredAddRegistration = "[dbo].[RegisterMarriage]";
		private static readonly string RegexEmail = MarryMe.Model.Resources.Validation.RegexEmail;
		private const string StoredApprove = "[dbo].[ApproveRegistration]";
		private static readonly string RegexPassId = MarryMe.Model.Resources.Validation.RegexPassId;
		#endregion

		#region Static

		private static string _fullUrl = string.Empty;
		private static string FullUrl
		{
			set
			{
				if (string.IsNullOrWhiteSpace(_fullUrl))
				{
					_fullUrl = value;
				}
			}
			get
			{
				return _fullUrl;
			}
		}

		#endregion

		#region members ICommonController

		/// <summary>
		/// Url to site.
		/// </summary>
		public string Url { get { return FullUrl; } set { FullUrl = value; } }

		/// <summary>
		/// Submit data about marriage.
		/// </summary>
		/// <param name="fullInfo">Full info.</param>
		/// <returns>Token.</returns>
		public virtual string SubmitData(MarriageFullInfo fullInfo)
		{
			Validation(fullInfo);
			var token = InsertData(fullInfo);

			return token;
		}


		/// <summary>
		/// Approve marriage.
		/// </summary>
		/// <param name="token">Token to get data.</param>
		public void ApproveData(string token)
		{
			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.CommandText = StoredApprove;

					DBFactory.AddParameter(command, "@token", token);
					command.ExecuteNonQuery();

				}
			}
		}

		#endregion

		#region Private implementation

		private string InsertData(MarriageFullInfo fullInfo)
		{
			string result = string.Empty;

			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.CommandText = StoredAddRegistration;

					#region marriage info
					DBFactory.AddParameter(command, "@regDateTime", fullInfo.RegistrationDate);
					DBFactory.AddParameter(command, "@roomId", fullInfo.RoomId);
					#endregion

					#region men info
					DBFactory.AddParameter(command, "@mName", fullInfo.Man.FirstName);
					DBFactory.AddParameter(command, "@mLastName", fullInfo.Man.LastName);
					DBFactory.AddParameter(command, "@mMidleName", fullInfo.Man.MiddleName);
					DBFactory.AddParameter(command, "@mTelNum", fullInfo.Man.TelephoneNumber);
					DBFactory.AddParameter(command, "@mPassportId", fullInfo.Man.PassportNumber);
					DBFactory.AddParameter(command, "@mEmail", fullInfo.Man.Email);
					#endregion

					#region women info
					DBFactory.AddParameter(command, "@wName", fullInfo.Woman.FirstName);
					DBFactory.AddParameter(command, "@wLastName", fullInfo.Woman.LastName);
					DBFactory.AddParameter(command, "@wMidleName", fullInfo.Woman.MiddleName);
					DBFactory.AddParameter(command, "@wTelNum", fullInfo.Woman.TelephoneNumber);
					DBFactory.AddParameter(command, "@wPassportId", fullInfo.Woman.PassportNumber);
					DBFactory.AddParameter(command, "@wEmail", fullInfo.Woman.Email);
					#endregion

					var token = command.ExecuteScalar();
					result = token.ToString();
				}
			}

			return result;
		}

		#region Validation
		private static void Validation(MarriageFullInfo fullInfo)
		{
			if (!string.IsNullOrWhiteSpace(fullInfo.Man.Email))
			{
				fullInfo.Man.Email = fullInfo.Man.Email.ToLower();
			}

			if (!string.IsNullOrWhiteSpace(fullInfo.Woman.Email))
			{
				fullInfo.Man.Email = fullInfo.Woman.Email.ToLower();
			}

			string manValidation = ValidateSpouse(fullInfo.Man, MarryMe.Model.Resources.Validation.Man);
			if (!string.IsNullOrWhiteSpace(manValidation))
			{
				throw new ArgumentNullException(manValidation);
			}

			string womanValidation = ValidateSpouse(fullInfo.Woman, MarryMe.Model.Resources.Validation.WoMan);
			if (!string.IsNullOrWhiteSpace(womanValidation))
			{
				throw new ArgumentNullException(womanValidation);
			}

			bool mEmailFilled = !string.IsNullOrWhiteSpace(fullInfo.Man.Email);

			if (!mEmailFilled)
			{
				throw new ArgumentException(MarryMe.Model.Resources.Validation.NoEmailMessage);
			}

			if (mEmailFilled)
			{
				if (!RegexCheck(fullInfo.Man.Email, RegexEmail))
				{
					throw new ArgumentException(MarryMe.Model.Resources.Validation.EmailNotValid);
				}
			}

			if (fullInfo.RegistrationDate < DateTime.Now)
			{
				throw new ArgumentNullException(MarryMe.Model.Resources.Validation.DateBelowNow);
			}

			if (!RegexCheck(fullInfo.Man.PassportNumber, RegexPassId)
				&& !RegexCheck(fullInfo.Woman.PassportNumber, RegexPassId))
			{
				throw new ArgumentException(MarryMe.Model.Resources.Validation.CheckPassportNum);
			}

		}

		private static string ValidateSpouse(Spouse sp, string spName)
		{
			sp.Email = TrimString(sp.Email);
			sp.LastName = TrimString(sp.LastName);
			sp.MiddleName = TrimString(sp.MiddleName);
			sp.PassportNumber = TrimString(sp.PassportNumber);
			sp.TelephoneNumber = TrimString(sp.TelephoneNumber);

			string result = string.Empty;
			
			if (string.IsNullOrWhiteSpace(sp.FirstName))
			{
				result = MarryMe.Model.Resources.Validation.NoName;
			}

			if (string.IsNullOrWhiteSpace(sp.MiddleName))
			{
				result = MarryMe.Model.Resources.Validation.NoSecondName;
			}

			if (string.IsNullOrWhiteSpace(sp.LastName))
			{
				result = MarryMe.Model.Resources.Validation.NoLastName;
			}

			result = string.Format(result, spName);

			return result;
		}

		private static bool RegexCheck(string check, string pattern)
		{
			Regex reg = new Regex(pattern);
			return reg.IsMatch(check);
		}

		private static string TrimString(string trimming)
		{
			string trimReturn = string.Empty;
			if (!string.IsNullOrWhiteSpace(trimming))
			{
				trimReturn = trimming.Trim();
			}
			return trimReturn;
		}

		#endregion

		#endregion
		
	}
}
