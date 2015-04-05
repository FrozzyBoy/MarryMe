namespace MarryMe.Model.Entity
{
	/// <summary>
	/// Statistics for day.
	/// </summary>
	public class DayStatistic
	{
		/// <summary>
		/// Rooms for day.
		/// </summary>
		public int[] ActiveRoomsId { get; set; }

		/// <summary>
		/// Day busy state.
		/// </summary>
		public int BusyDays { get; set; }
	}
}
