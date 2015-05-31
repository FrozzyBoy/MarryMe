using System;
using MarryMe.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerryMe.Model.Test
{
	[TestClass]
	public class SubmitDataTest
	{
		[TestMethod]
		public void TestSendEmail()
		{
			var ctl = new CommonEmailSenderController();
			var result = "";

			try
			{
				result = ctl.SubmitData(null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsTrue(result == string.Empty);
		}
	}
}
