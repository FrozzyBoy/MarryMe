namespace MarryMe.WebApi
{
	#region using
	using System;
	using System.Web.Http;
	using System.Web.Http.Cors;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using MarryMe.Model.Resources;
	using System.Net;
	using Newtonsoft.Json;
	using MarryMe.Model;
	#endregion

	/// <summary>
	/// Общие данные.
	/// </summary>
	[RoutePrefix("api")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[AllowAnonymous]
	public class CommonController : ApiController
	{
		private ICommonController _controller;

		#region Constructor

		public CommonController(ICommonController controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("Common is null.");
			}

			_controller = controller;

		}

		#endregion

		#region http get

		/// <summary>
		/// Test get.
		/// </summary>
		/// <returns>return true.</returns>
		[HttpGet]
		[Route("Test")]
		public bool Test()
		{
			return true;
		}

		#endregion

		#region http post

		[HttpPost]
		[Route("submit")]
		public IHttpActionResult PostData([FromBody] MarriageFullInfo marige)
		{
			const string secret = "6LdNoAcTAAAAAA967BP-nJHUKJI-uySm4Gffw6ck";
			var client = new WebClient();
			var reply =
				client.DownloadString(
					string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, marige.CaptchaResponse));

			var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
			
			
			try
			{
				if (captchaResponse.Success)
				{
					return Ok(_controller.SubmitData(marige));
				}
				else
				{
					return BadRequest("Ошибка при проверке капчи");
				}
				
			}
			catch (ArgumentException ex)
			{
				return BadRequest(Helper.Validation.ValidateException(ex.Message));
			}
			catch (Exception ex)
			{
				return BadRequest(Helper.Validation.ValidateException(ex.Message));
			}
		}

		#endregion

	}
}
