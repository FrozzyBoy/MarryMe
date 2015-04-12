namespace MarryMe.WebApi
{
	#region Using

	using System;
	using System.Web.Http;
	using System.Web.Http.Cors;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	using MarryMe.Model.Resources;

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

		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="calendar">Calendar statistic.</param>
		public CalendarController(ICalendarData calendar)
		{
			if (calendar == null)
			{
				throw new ArgumentNullException("Calendar is null.");
			}

			_calendar = calendar;
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
		/// Get statistics for year.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns></returns>
		[HttpGet]
		[Route("months")]
		public IHttpActionResult GetMonthlyStats(int year)
		{
			int[] result = _calendar.GetMonthStatistic(year);
			return Ok(result);
		}

		/// <summary>
		/// Get statistic for selected month.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("days")]
		public IHttpActionResult GetDayStatistics(int year, int month)
		{
			int daysInMonth = DateTime.DaysInMonth(year, month);
			var result = Ok(_calendar.GetStatisticForDays(year, month));

			return result;
		}

		/// <summary>
		/// Get Holidays.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("holidays")]
		public IHttpActionResult GetHolidays(int year, int month)
		{
			int daysInMonth = DateTime.DaysInMonth(year, month);
			var result = _calendar.GetHolidaysForMonth(year, month);

			return Ok(result);
		}

		#endregion

		#endregion

	}
}
