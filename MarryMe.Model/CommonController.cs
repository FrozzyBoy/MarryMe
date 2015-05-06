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

		#endregion

		#region members ICommonController
		/// <summary>
		/// Submit data about marriage.
		/// </summary>
		/// <param name="fullInfo">Full info.</param>
		/// <returns>True if ok.</returns>
		public bool SubmitData(MarriageFullInfo fullInfo)
		{
			Validation(fullInfo);
			InsertData(fullInfo);

			return true;
		}
		#endregion

		private void InsertData(MarriageFullInfo fullInfo)
		{
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

					command.ExecuteNonQuery();
				}
			}
		}

		private void Validation(MarriageFullInfo fullInfo)
		{
			bool wEmailFilled = !string.IsNullOrWhiteSpace(fullInfo.Woman.Email);
			bool mEmailFilled = !string.IsNullOrWhiteSpace(fullInfo.Man.Email);

			if (!wEmailFilled
				|| !mEmailFilled)
			{
				throw new ArgumentException("Нужно указать электронную почту хотя бы одного брачующегося.");
			}

			if (wEmailFilled)
			{
				if (!CheckMail(fullInfo.Woman.Email))
				{
					throw new ArgumentException("Электронный адрес супруги заполнен не правильно.");
				}
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

		private bool CheckMail(string mail)
		{
			Regex reg = new Regex(RegexEmail);
			return reg.IsMatch(mail);
		}

	}
}
