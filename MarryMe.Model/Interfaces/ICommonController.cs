namespace MarryMe.Model.Interfaces
{
	#region using

	using MarryMe.Model.Entity;

	#endregion

	public interface ICommonController
	{
		/// <summary>
		/// Url to site.
		/// </summary>
		string Url { get; set; }

		/// <summary>
		/// Submit data about marriage.
		/// </summary>
		/// <param name="fullInfo">Full info.</param>
		/// <returns>Token.</returns>
		string SubmitData(MarriageFullInfo fullInfo);

		/// <summary>
		/// Approve marriage.
		/// </summary>
		/// <param name="token">Token to get data.</param>
		void ApproveData(string token);
	}
}
