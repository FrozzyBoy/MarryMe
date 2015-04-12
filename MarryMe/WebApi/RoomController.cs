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
	/// API to get room info.
	/// </summary>
	[RoutePrefix("api/room")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
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

		[HttpGet]
		[Route("count")]
		public IHttpActionResult GetRoomsCount()
		{
			return Ok(_room.GetRoomsCount());
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
			IHttpActionResult result = Ok(_room.GetInformation(roomId));
			return result;
		}

		[HttpGet]
		[Route("schedule")]
		public IHttpActionResult GetRoomSchedule(int roomId, string time)
		{
			DateTime timeParsed = DateTime.Parse(time);

			DateSchedule[] result = _room.GetSchedule(roomId, timeParsed);

			return Ok(result);
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
