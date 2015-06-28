namespace MarryMe.Model.Entity
{

	#region Using

	using Newtonsoft.Json;
	using System.Collections.Generic;

	#endregion

	public class CaptchaResponse
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("error-codes")]
		public List<string> ErrorCodes { get; set; }
	}
}
