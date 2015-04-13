namespace MarryMe.Model.Entity
{
	#region Using

	using System;

	#endregion

	public class DateSchedule
	{
		public TimeSpan Time { get; set; }
		public bool IsUsing { get; set; }
	}
}
