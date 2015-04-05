﻿namespace MarryMe.Model.Entity
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
		public string FatherName { get; set; }
		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		public string TelephoneNumber { get; set; }
		public string PassportNumber { get; set; }

	}
}
