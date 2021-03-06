﻿namespace MarryMe.Controllers
{
	#region Using
	using System;
	using System.Web.Mvc;
	using MarryMe.Model;
	using MarryMe.Model.Interfaces;
	
	#endregion
	public class HomeController : Controller
	{
		private readonly ICommonController _common;

		public HomeController(ICommonController common)
		{
			_common = common;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult IndexTwo()
		{
			return View();
		}

		public ActionResult MarryMe()
		{
			var contactUsUrlBuilder =
			new UriBuilder(Request.Url.AbsoluteUri)
			{
				Path = Url.Action("Approve", "Home")
			};

			var contactUsUriString = contactUsUrlBuilder.ToString();

			_common.Url = contactUsUriString + "/";
			return View();
		}

		public ActionResult Modal()
		{
			return View();
		}

		public ActionResult Approve(string id)
		{
			var model = new ApproveModel() { IsApproved = true };

			try
			{
				_common.ApproveData(id);
			}
			catch (Exception ex)
			{
				model.IsApproved = false;
				model.Message = Helper.Validation.ValidateException(ex.Message);
			}
			return View(model);
		}

	}
}