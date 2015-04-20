namespace MarryMe.Model
{
	#region Using

	using System;
	using System.Threading;
	using MarryMe.Model.Entity;
	using MarryMe.Model.Interfaces;

	#endregion

	public class CommonController : ICommonController
	{
		/// <summary>
		/// Submit data obout marrige.
		/// </summary>
		/// <param name="fullInfo">Full info.</param>
		/// <returns>True if ok.</returns>
		public bool SubmitData(MarriageFullInfo fullInfo)
		{
			Thread.Sleep(1500);
			return true;
		}
	}
}
