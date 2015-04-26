namespace MarryMe.Model
{
	#region Using
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Factory;
	using MarryMe.Model.Interfaces;
	#endregion

	public class RoomData : IRoomData
	{

		#region Constants

		private const string StoredGetRoomById = "[dbo].[GetRoomById]";
		private const string StoredGetAllRooms = "[dbo].[GetAllRooms]";
		private const string StoredGetSheduleRoom = "[dbo].[GetSheduleRoom]";

		#endregion

		#region implement IRoomData
		/// <summary>
		/// Room info.
		/// </summary>
		/// <param name="roomId">Room id.</param>
		/// <returns></returns>
		public Room GetInformation(int roomId)
		{
			Room room = null;

			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.CommandText = StoredGetRoomById;

					DBFactory.AddParameter(command, "@roomId", roomId);

					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							room = Room.ParseReader(reader);
						}
					}
				}
			}

			return room;
		}

		/// <summary>
		/// Расписание для дня
		/// </summary>
		/// <param name="roomId"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		public DateSchedule[] GetSchedule(int roomId, DateTime day)
		{
			List<DateSchedule> result = new List<DateSchedule>();

			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.CommandText = StoredGetSheduleRoom;

					DBFactory.AddParameter(command, "@roomId", roomId);
					DBFactory.AddParameter(command, "@date", day.Date);

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var shedule = DateSchedule.ParseReader(reader);
							result.Add(shedule);
						}
					}
				}
			}

			return result.ToArray();
		}

		/// <summary>
		/// Get all rooms.
		/// </summary>
		/// <returns></returns>
		public Room[] GetRooms()
		{
			List<Room> rooms = new List<Room>();

			using (var connection = DBFactory.GetConnection())
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;
					command.CommandText = StoredGetAllRooms;
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var room = Room.ParseReader(reader);
							rooms.Add(room);
						}
					}
				}
			}

			return rooms.ToArray();

		}

		#endregion

	}
}
