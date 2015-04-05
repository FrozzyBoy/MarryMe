using MarryMe.Model.Entity;
namespace MarryMe.Model.Interfaces
{
	/// <summary>
	/// Calendar data interface.
	/// </summary>
	public interface ICalendarData
	{
		#region Methods
		/// <summary>
		/// Get every day statistic for month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns>Return busy stats for day. Index is day -1.</returns>
		int[] GetMonthStatistic(int year, int month);

		/// <summary>
		/// Get statistic for current day.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <param name="day">Day to get statistic.</param>
		/// <returns></returns>
		DayStatistic GetStatisticForDay(int year, int month, int day);

		/// <summary>
		/// Get holiday that in selected month.
		/// </summary>
		/// <param name="year">selected year</param>
		/// <param name="month">selected month.</param>
		/// <returns></returns>
		Holiday[] GetHolidaysForMonth(int year, int month);

		/// <summary>
		/// Submit marrige.
		/// </summary>
		/// <param name="marige">marige info</param>
		/// <returns></returns>
		bool SubmitData(MarriageFullInfo marige);

		#endregion
	}
}
