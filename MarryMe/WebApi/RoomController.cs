namespace MarryMe.WebApi
{
	#region using
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using System;
	using System.Web.Http;
	#endregion

	/// <summary>
	/// API to get room info.
	/// </summary>
	[RoutePrefix("api/room")]
	[AllowAnonymous]
	public class RoomController : ApiController
	{
		private IRoomData _room;

		#region Constructor

		public RoomController(IRoomData room)
		{
			if (room == null)
			{
				throw new ArgumentNullException("Room is null.");
			}
			_room = room;
		}

		#endregion

		#region Web API
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

		/// <summary>
		/// Get statistic for selected room.
		/// </summary>
		/// <param name="roomId"></param>
		/// <param name="selectedTime"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("info")]
		public IHttpActionResult GetRoomInformation(int roomId)
		{
			try
			{
				IHttpActionResult result = Ok(_room.GetInformation(roomId));
				return result;
			}
			catch
			{
				return BadRequest("");
			}
		}

		[HttpGet]
		[Route("schedule")]
		public IHttpActionResult GetRoomSchedule(int roomId, string time)
		{
			DateTime timeParsed;
			if (DateTime.TryParse(time, out timeParsed))
			{
				DateSchedule[] result = _room.GetSchedule(roomId, timeParsed);

				return Ok(result);
			}
			return BadRequest("Дата не корректна.");
		}

		[HttpGet]
		[Route("all")]
		public IHttpActionResult GetAllRooms()
		{
			return Ok(_room.GetRooms());
		}

		#endregion
		#endregion
	}
}
