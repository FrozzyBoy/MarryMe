namespace MarryMe.WebApi
{
	#region Using

	using System;
	using System.Web.Http;
	using System.Web.Http.Cors;
	using MarryMe.Model.Interfaces;

	#endregion

	/// <summary>
	/// Web api controll for calendar.
	/// </summary>
	//[ValidateHttpAntiForgeryToken]
	[RoutePrefix("api/calendar")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[AllowAnonymous]
	public class CalendarController : ApiController
	{
		/// <summary>
		/// Calendar statistic.
		/// </summary>
		private ICalendarData _calendar = null;

		private IRoomData _room;

		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="calendar">Calendar statistic.</param>
		public CalendarController(ICalendarData calendar, IRoomData room)
		{
			if (calendar == null)
			{
				throw new ArgumentNullException("Calendar is null.");
			}

			if (room == null)
			{
				throw new ArgumentNullException("Room is null.");
			}

			_calendar = calendar;
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
		/// Get statistics for month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns></returns>
		[HttpGet]
		[Route("month")]
		public IHttpActionResult GetMonthlyStats(int year, int month)
		{
			var result = _calendar.GetMonthStatistic(year, month);
			return Ok(result);
		}

		/// <summary>
		/// Get statistic for selected day.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("day")]
		public IHttpActionResult GetDayStatistics(int year, int month, int day)
		{
			int daysInMonth = DateTime.DaysInMonth(year, month);
			var isValid = (day > 0 && day <= daysInMonth);

			IHttpActionResult result = BadRequest("Плохая дата.");

			if (isValid)
			{
				result = Ok(_calendar.GetStatisticForDay(year, month, day));
			}

			return result;
		}

		/// <summary>
		/// Get Holidays.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("Holidays")]
		public IHttpActionResult GetHolidays(int year, int month)
		{
			var result = _calendar.GetHolidaysForMonth(year, month);
			return Ok(result);
		}

		/// <summary>
		/// Get statistic for selected room.
		/// </summary>
		/// <param name="roomId"></param>
		/// <param name="selectedTime"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("room")]
		public IHttpActionResult GetRoomStatistic(int roomId, string selectedTime = null)
		{
			IHttpActionResult result = null;

			if (selectedTime == null)
			{
				result = BadRequest("Дата null");
			}
			else
			{
				DateTime date;
				DateTime.TryParse(selectedTime, out date);

				if (date == null)
				{
					result = BadRequest("Не смог спарсить дату");
				}
				else
				{
					result = Ok(_room.GetRoomStats(roomId, date));
				}
			}

			return result;
		}

		#endregion

		#endregion

	}
}
