using System;
using System.Text.RegularExpressions;

namespace MarryMe.Helper
{
	public static class Validation
	{
		public static string ValidateException(string msg)
		{
			Regex reg = new Regex("[a-zA-Z]");
			var ret = reg.Replace(msg, "");

			char[] charsToTrim = new char[] {' ', '.', '@', '\\', '/', '-', '\'', '"', ',' };
			ret = ret.Trim(charsToTrim);

			return ret;
		}
	}
}