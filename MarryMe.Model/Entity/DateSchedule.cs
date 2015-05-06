namespace MarryMe.Model.Entity
{
	#region Using

	using System;
	using System.Data;

	#endregion

	public class DateSchedule
	{
		#region Static

		public static DateSchedule ParseReader(IDataReader reader)
		{
			DateSchedule result = new DateSchedule();

			result.IsUsing = reader.GetBoolean(reader.GetOrdinal("IsFree"));
			var registerTime = reader.GetDateTime(reader.GetOrdinal("RegisterTime"));
            result.Time = registerTime.TimeOfDay;

			return result;
		}

		#endregion

		public TimeSpan Time { get; set; }
		public bool IsUsing { get; set; }
	}
}
