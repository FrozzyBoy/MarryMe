namespace MarryMe.Model
{
	#region Using
	using System;
	using MarryMe.Model.Interfaces;
	using MarryMe.Model.Resources;
	#endregion

	public class CommonEmailSenderController : CommonController, ICommonController
	{

		#region Private memebers

		private IRoomData _room = null;

		#endregion

		#region constructor
		public CommonEmailSenderController(IRoomData room)
		{
			if (room == null)
			{
				throw new ArgumentNullException("room");
			}

			_room = room;
		} 
		#endregion

		public override string SubmitData(Entity.MarriageFullInfo fullInfo)
		{
			var token = base.SubmitData(fullInfo);

			SendEmail(token, fullInfo);

			return token;
		}

		private void SendEmail (string token, Entity.MarriageFullInfo fullInfo)
		{
			System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
			var msg = new System.Net.Mail.MailMessage();
			msg.To.Add(fullInfo.Man.Email);
			msg.Subject = "Подтверждение регистрации.";
			msg.IsBodyHtml = true;
			msg.Priority = System.Net.Mail.MailPriority.High;
			msg.Body = string.Format( PagesRes.ApproveEmail, 
				fullInfo.RegistrationDate.ToString(), _room.GetInformation(fullInfo.RoomId).Name, 
				fullInfo.Man.FirstName, fullInfo.Man.LastName, fullInfo.Man.MiddleName, fullInfo.Man.TelephoneNumber ?? "",
				fullInfo.Woman.FirstName, fullInfo.Woman.LastName, fullInfo.Woman.MiddleName, fullInfo.Woman.TelephoneNumber ?? "",
				base.Url + token);
			client.Send(msg);
		}

	}
}
