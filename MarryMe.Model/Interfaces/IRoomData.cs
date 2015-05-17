namespace MarryMe.Model.Interfaces
{
	#region Using
	using System;
	using MarryMe.Model.Entity;
	#endregion

	/// <summary>
	///  Data for room.
	/// </summary>
	public interface IRoomData
	{
		/// <summary>
		/// Room info.
		/// </summary>
		/// <param name="roomId">Room id.</param>
		/// <returns></returns>
		Room GetInformation(int roomId);

		/// <summary>
		/// Расписание для дня
		/// </summary>
		/// <param name="roomId"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		DateSchedule[] GetSchedule(int roomId, DateTime time);

		/// <summary>
		/// Get all rooms.
		/// </summary>
		/// <returns></returns>
		Room[] GetRooms();
	}
}
