namespace MarryMe.Model.Entity
{

	#region Using

	using System;

	#endregion

	/// <summary>
	/// Room data.
	/// </summary>
	public class Room
	{
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
