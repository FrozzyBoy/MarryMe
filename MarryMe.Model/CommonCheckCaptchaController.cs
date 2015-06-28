namespace MarryMe.Model
{
	#region Using

	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using Newtonsoft.Json;
	using System;
	using System.Net;

	#endregion

	public class CommonCheckCaptchaController : CommonEmailSenderController, ICommonController
	{
		private static readonly string secret = "6LdNoAcTAAAAAA967BP-nJHUKJI-uySm4Gffw6ck";
		private static readonly string googleApi = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";


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
