namespace MarryMe.Model.Entity
{
	#region Using

	using System;
	using System.Collections.Generic;

	#endregion

	/// <summary>
	/// Data to submit about marriage.
	/// </summary>
	public class MarriageFullInfo
	{
		public int RoomId { get; set; }

		public DateTime RegistrationDate { get; set; }

		public Spouse Man { get; set; }
		public Spouse Woman { get; set; }
	}
}
