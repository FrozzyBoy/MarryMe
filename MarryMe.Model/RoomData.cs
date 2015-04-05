namespace MarryMe.Model
{
	#region Using
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;
	#endregion

	public class RoomData : IRoomData
	{
		/// <summary>
		/// Stats for room.
		/// </summary>
		/// <param name="roomId">Room id.</param>
		/// <param name="selectedTime">Time for room.</param>
		/// <returns></returns>
		public Room[] GetRoomStats(int roomId, DateTime? selectedTime)
		{
			Room[] rooms = new Room[] { new Room() { Id = 1, Information = "информация", Name = "Розовая комната", EmptyPlaces = new DateTime[] { (DateTime)(selectedTime) }, Price = 10 } };
			return rooms;
		}
	}
}
