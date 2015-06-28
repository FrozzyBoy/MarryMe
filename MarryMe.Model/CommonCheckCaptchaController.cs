namespace MarryMe.Model
{
	#region Using

	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using Newtonsoft.Json;
	using System;
	using System.Configuration;
	using System.Net;

	#endregion

	public class CommonCheckCaptchaController : CommonEmailSenderController, ICommonController
	{
		private static readonly string secret = ConfigurationManager.AppSettings["secret"];
		private static readonly string googleApi = ConfigurationManager.AppSettings["googleApi"];

		#region constructor
		public CommonCheckCaptchaController(IRoomData room) : base(room) { }
		#endregion

		public override string SubmitData(MarriageFullInfo fullInfo)
		{
			using (var client = new WebClient())
			{
				var reply =
					client.DownloadString(
						string.Format(googleApi, secret, fullInfo.CaptchaResponse));

				var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

				if (!captchaResponse.Success)
				{
					throw new ArgumentException("Пройдите капчу.");
				}

				return base.SubmitData(fullInfo);
			}
		}
	}
}
