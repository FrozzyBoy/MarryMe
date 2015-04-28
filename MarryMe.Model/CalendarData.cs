namespace MarryMe.Model
{
	#region Using

	using System;
	using System.Collections.Generic;
	using System.Data.Common;
	using System.Threading;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Factory;
	using MarryMe.Model.Interfaces;

	#endregion
	/// <summary>
	/// ReturnDa
	/// </summary>
	public class CalendarData : ICalendarData
	{
		#region Constants

		private const int MonthsInYear = 12;
		private const string StoredMonthStat = "[dbo].[GetStatisticForMonthInYear]";
		private const string StoredDaysStat = "[dbo].[GetStatisticForAllDaysInMonth]";
		private const string StoredHolidays = "[dbo].[GetHolidaysForMonth]";

		#endregion

		#region Члены ICalendarData

		/// <summary>
		/// Get every day statistic for month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns>Return busy stats for day. Index is day -1.</returns>
		public int[] GetMonthStatistic(int year)
		{
			List<int> days = new List<int>();

			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = StoredMonthStat;
					command.CommandType = System.Data.CommandType.StoredProcedure;

					string yearParam = string.Format("{0}-1-1", year);

					command.Parameters.Clear();
					DBFactory.AddParameter(command, "@firstDayOfMoth", yearParam);
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var parseData = (int)(reader[DBFactory.StatisticOutData]);
							days.Add(parseData);
						}
					}

				}

			}

			return days.ToArray();

		}

		/// <summary>
		/// Get statistic days in month.
		/// </summary>
		/// <param name="year">Year to get statistic.</param>
		/// <param name="month">Month to get statistic.</param>
		/// <returns></returns>
		public int[] GetStatisticForDays(int year, int month)
		{
			var result = new List<int>();
			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				string yearParam = string.Empty;
				using (var command = connection.CreateCommand())
				{
					command.CommandText = StoredDaysStat;
					command.CommandType = System.Data.CommandType.StoredProcedure;

					yearParam = string.Format("{0}-{1}-1", year, month);

					command.Parameters.Clear();
					DBFactory.AddParameter(command, "@firstDayOfMoth", yearParam);

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var parseData = (int)(reader[DBFactory.StatisticOutData]);
							result.Add(parseData);
						}
					}

				}
			}

			return result.ToArray();
		}

		/// <summary>
		/// Get holiday that in selected month.
		/// </summary>
		/// <param name="year">selected year</param>
		/// <param name="month">selected month.</param>
		/// <returns></returns>
		public Holiday[] GetHolidaysForMonth(int year, int month)
		{
			List<Holiday> result = new List<Holiday>();

			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.CommandText = StoredHolidays;

					DBFactory.AddParameter(command, "@year", year);
					DBFactory.AddParameter(command, "@month", month);

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							string info = reader.GetString(reader.GetOrdinal("Information"));
							DateTime st = reader.GetDateTime(reader.GetOrdinal("StartDay"));
							DateTime end = reader.GetDateTime(reader.GetOrdinal("EndDay"));
							result.Add(new Holiday() { Information = info, EndDay = end, StartDay = st });
						}
					}

				}
			}

			return result.ToArray();
		}

		#endregion
	}
}