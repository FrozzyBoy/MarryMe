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
		public int[] GetMonthStatistic(int year, int month)
		{
			Thread.Sleep(3000);

			int numDays = DateTime.DaysInMonth(year, month);

			Random rnd = new Random();
			int[] days = new int[numDays];

			for (int i = 0; i < numDays; i++)
			{
				days[i] = rnd.Next(100);
			}

			return days;
		}

		/// <summary>
		/// Get statistic for current day.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <param name="day">Day to get statistic.</param>
		/// <returns></returns>
		public DayStatistic GetStatisticForDay(int year, int month, int day)
		{
			Thread.Sleep(3000);

			DayStatistic result = new DayStatistic();

			Random rnd = new Random();

			var list = new List<int>();

			for (int i = 0; i < 5; i++)
			{
				if (rnd.Next(100) > 50)
				{
					list.Add(i);
				}
			}

			result.ActiveRoomsId = list.ToArray();
			result.BusyDays = rnd.Next(100);

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

		/// <summary>
		/// Submit marrige.
		/// </summary>
		/// <param name="marige">marige info</param>
		/// <returns></returns>
		public bool SubmitData(MarriageFullInfo marige)
		{
			Thread.Sleep(5000);
			return true;
		}

		#endregion
	}
}