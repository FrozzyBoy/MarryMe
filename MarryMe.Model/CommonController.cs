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
		private const string RegexEmail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
		private const string StoredApprove = "[dbo].[ApproveRegistration]";

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
		private void Validation(MarriageFullInfo fullInfo)
		{
			string manValidation = ValidateSpouse(fullInfo.Man, "жениха");
			if (!string.IsNullOrWhiteSpace(manValidation))
			{
				throw new ArgumentNullException(manValidation);
			}

			bool mEmailFilled = !string.IsNullOrWhiteSpace(fullInfo.Man.Email);

			if (!mEmailFilled)
			{
				throw new ArgumentException("Нужно указать электронную почту для подтверждения регистрации.");
			}

			if (mEmailFilled)
			{
				if (!CheckMail(fullInfo.Man.Email))
				{
					throw new ArgumentException("Электронный адрес супруга заполнен не правильно.");
				}
			}

			if (fullInfo.RegistrationDate < DateTime.Now)
			{
				throw new ArgumentNullException("Нужно выбрать время в будущем.");
			}
		}

		private string ValidateSpouse(Spouse sp, string spName)
		{
			string result = string.Empty;

			if (string.IsNullOrWhiteSpace(sp.FirstName))
			{
				result = "Имя {0} нужно обязательно заполнить.";
			}

			if (string.IsNullOrWhiteSpace(sp.MiddleName))
			{
				result = "Отчество {0} нужно обязательно заполнить.";
			}

			if (string.IsNullOrWhiteSpace(sp.LastName))
			{
				result = "Фамилию {0} нужно обязательно заполнить.";
			}

			result = string.Format(result, spName);

			return result;
		}

		private bool CheckMail(string mail)
		{
			Regex reg = new Regex(RegexEmail);
			return reg.IsMatch(mail);
		}
		#endregion

	}
}
