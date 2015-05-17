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
		/// Get month busy state.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <returns>Return busy for month.</returns>
		int[] GetMonthStatistic(int year);

		/// <summary>
		/// Get statistic days in month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns></returns>
		int[] GetStatisticForDays(int year, int month);

		/// <summary>
		/// Get holiday that in selected month.
		/// </summary>
		/// <param name="year">selected year</param>
		/// <param name="month">selected month.</param>
		/// <returns></returns>
		Holiday[] GetHolidaysForMonth(int year, int month);
				
		#endregion
	}
}
