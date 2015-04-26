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
			string registerTime = reader.GetString(reader.GetOrdinal("RegisterTime"));
			result.Time = TimeSpan.Parse(registerTime);

			return result;
		}

		#endregion

		public TimeSpan Time { get; set; }
		public bool IsUsing { get; set; }
	}
}
