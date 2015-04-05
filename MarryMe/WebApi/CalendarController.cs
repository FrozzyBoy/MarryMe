namespace MarryMe.WebApi
{
	#region Using
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	#endregion

	/// <summary>
	/// Web api controll for calendar.
	/// </summary>
	//[ValidateHttpAntiForgeryToken]
	[RoutePrefix("api/calendar")]
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
		public IHttpActionResult Test()
		{
			return Json<bool>(true);
		}

		/// <summary>
		/// Get statistics for month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns></returns>
		[Route("month")]
		public IHttpActionResult GetMonthlyStats(int year, int month)
		{
			var result = Json<int[]>(_calendar.GetMonthStatistic(year, month));
			return Ok(result);
		}

		/// <summary>
		/// Get statistic for selected day.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		[Route("day")]
		public IHttpActionResult GetDayStatistics(int year, int month, int day)
		{
			int daysInMonth = DateTime.DaysInMonth(year, month);
			var isValid = (day > 0 && daysInMonth <= day);

			IHttpActionResult result = Json<string>("Плохая дата.");

			if (isValid)
			{
				result = Json<object>(_calendar.GetStatisticForDay(year, month, day));
			}

			return result;
		}

		/// <summary>
		/// Get Holidays.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <returns></returns>
		[Route("Holidays")]
		public IHttpActionResult GetHolidays(int year, int month)
		{
			var result = Json<Array>(_calendar.GetHolidaysForMonth(year, month));
			return result;
		}

		/// <summary>
		/// Get statistic for selected room.
		/// </summary>
		/// <param name="roomId"></param>
		/// <param name="selectedTime"></param>
		/// <returns></returns>
		public IHttpActionResult GetRoomStatistic(int roomId, DateTime? selectedTime = null)
		{
			return Json<Room[]>(_room.GetRoomStats(roomId, selectedTime));
		}

		#endregion

		#endregion

	}
}
