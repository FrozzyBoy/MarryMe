namespace MarryMe.Model.Interfaces
{
	#region using

	using MarryMe.Model.Entity;

	#endregion

	public interface ICommonController
	{
		/// <summary>
		/// Submit data obout marrige.
		/// </summary>
		/// <param name="fullInfo">Full info.</param>
		/// <returns>True if ok.</returns>
		bool SubmitData(MarriageFullInfo fullInfo);
	}
}
