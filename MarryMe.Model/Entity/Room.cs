namespace MarryMe.Model.Entity
{

	#region Using

	using System;
	using System.Data;

	#endregion

	/// <summary>
	/// Room data.
	/// </summary>
	public class Room
	{
		#region static

		public static Room ParseReader(IDataReader reader)
		{
			Room result = new Room();

			result.Id = reader.GetInt32(reader.GetOrdinal("Id"));
			result.Name = reader.GetString(reader.GetOrdinal("Name"));
			result.Price = 0;
			result.Information = "";

			return result;
		}

		#endregion

		/// <summary>
		/// Id column.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Room name.
		/// </summary>			 
		public string Name { get; set; }

		/// <summary>
		/// Room Information.
		/// </summary>
		public string Information { get; set; }

		/// <summary>
		/// Room price.
		/// </summary>
		public int Price { get; set; }
	}
}
