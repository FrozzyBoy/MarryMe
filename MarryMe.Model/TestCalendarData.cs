namespace MarryMe.Model
{
	#region Using

	using System;
	using System.Collections.Generic;
	using System.Threading;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;

	#endregion
	/// <summary>
	/// ReturnDa
	/// </summary>
	public class TestCalendarData : ICalendarData
	{
		#region Члены ICalendarData

		/// <summary>
		/// Get every day statistic for month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns>Return busy stats for day. Index is day -1.</returns>
		public int[] GetMonthStatistic(int year)
		{
			Thread.Sleep(1000);

			Random rnd = new Random();
			int[] days = new int[12];

			for (int i = 0; i < 12; i++)
			{
				days[i] = rnd.Next(100);
			}

			return days;
		}

		/// <summary>
		/// Get statistic dayes in month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns></returns>
		public int[] GetStatisticForDays(int year, int month)
		{
			Thread.Sleep(1000);

			Random rnd = new Random();

			var result = new int[DateTime.DaysInMonth(year, month)];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = rnd.Next(100);
			}

			return result;
		}

		/// <summary>
		/// Get holiday that in selected month.
		/// </summary>
		/// <param name="year">selected year</param>
		/// <param name="month">selected month.</param>
		/// <returns></returns>
		public Holiday[] GetHolidaysForMonth(int year, int month)
		{
			Holiday[] result = new Holiday[] { 
				new Holiday(){ Infomatin="День валяния дурака", StartDay=new DateTime(year, month, 15), EndDay= new DateTime(year, month, 15)},
				new Holiday(){Infomatin="Нельзя жениться а то беда", StartDay=new DateTime( year, month, 6 ), EndDay=new DateTime(year, month, 13)}
			};

			return result;
		}

		#endregion
	}
}