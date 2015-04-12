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

		private Room[] _rooms = new Room[]{new Room()
				{
					Id = 0,
					Information = "информация",
					Name = "Розовая комната",
					Price = 10
				},
		new Room()
				{
					Id = 1,
					Information = "информация",
					Name = "не Розовая комната",
					Price = 10
				}};

		#region implement IRoomData
		/// <summary>
		/// Room info.
		/// </summary>
		/// <param name="roomId">Room id.</param>
		/// <returns></returns>
		public Room GetInformation(int roomId)
		{
			return _rooms[roomId];
		}

		/// <summary>
		/// Расписание для дня
		/// </summary>
		/// <param name="roomId"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		public DateSchedule[] GetSchedule(int roomId, DateTime day)
		{
			var elapse = new TimeSpan(0, 20, 0);
			TimeSpan st = new TimeSpan(8, 0, 0);
			TimeSpan end = new TimeSpan(17, 55, 0);
			List<DateSchedule> result = new List<DateSchedule>();

			var rnd = new Random();

			for (TimeSpan i = st; i < end; i += elapse)
			{
				result.Add(new DateSchedule() { IsUsing = rnd.Next(100) < 50, Time = i });
			}

			return result.ToArray();
		}


		/// <summary>
		/// Get rooms count.
		/// </summary>
		/// <returns>Rooms Count.</returns>
		public int GetRoomsCount()
		{
			return _rooms.Length;
		}

		/// <summary>
		/// Get all rooms.
		/// </summary>
		/// <returns></returns>
		public Room[] GetRooms()
		{
			return _rooms;
		}

		#endregion

	}
}
