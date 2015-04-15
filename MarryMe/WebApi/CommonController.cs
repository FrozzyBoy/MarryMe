namespace MarryMe.WebApi
{
	#region using
	using System;
	using System.Web.Http;
	using System.Web.Http.Cors;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using MarryMe.Model.Resources;
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
			marige.SubmitDate = DateTime.Now;
			marige.Method = Text.MethodOfThreatMent;

			bool result = _controller.SubmitData(marige);

			if (result)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		#endregion

	}
}
