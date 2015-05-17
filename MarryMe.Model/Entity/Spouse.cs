namespace MarryMe.Model.Entity
{
	#region Using

	using System;

	#endregion

	/// <summary>
	/// Супруг.
	/// </summary>
	public class Spouse
	{
		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }
		/// <summary>
		/// Отчество.
		/// </summary>
		public string MiddleName { get; set; }
		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		public string TelephoneNumber { get; set; }
		public string PassportNumber { get; set; }
		public string Email { get; set; }

	}
}
