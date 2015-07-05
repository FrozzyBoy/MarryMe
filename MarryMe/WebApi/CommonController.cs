namespace MarryMe.WebApi
{
	#region using
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using System;
	using System.Web.Http;
	using System.Data.Common;
	#endregion

	/// <summary>
	/// Общие данные.
	/// </summary>
	[RoutePrefix("api")]
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
			try
			{
				return Ok(_controller.SubmitData(marige));
			}
			catch (ArgumentException ex)
			{
				return BadRequest(Helper.Validation.ValidateException(ex.Message));
			}
			catch (DbException ex)
			{
				return BadRequest(Helper.Validation.ValidateException(ex.Message));
			}
			catch (Exception)
			{
				return BadRequest("Произошла ошибка. Повторите регистрацию.");
			}
		}

		#endregion

	}
}
