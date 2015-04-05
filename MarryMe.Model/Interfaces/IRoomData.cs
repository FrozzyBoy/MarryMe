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
		/// Stats for room.
		/// </summary>
		/// <param name="roomId">Room id.</param>
		/// <param name="selectedTime">Time for room.</param>
		/// <returns></returns>
		Room[] GetRoomStats(int roomId, DateTime? selectedTime);
	}
}
