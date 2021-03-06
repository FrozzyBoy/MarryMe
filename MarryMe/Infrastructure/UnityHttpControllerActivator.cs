﻿namespace MarryMe.Infrastructure
{
	#region Using
	using System;
	using System.Net.Http;
	using System.Web.Http.Controllers;
	using System.Web.Http.Dispatcher;
	using Microsoft.Practices.Unity;
	#endregion

	/// <summary>
	/// Unity activate web api.
	/// </summary>
	public class UnityHttpControllerActivator : IHttpControllerActivator
	{
		private readonly IUnityContainer _container;

		public UnityHttpControllerActivator(IUnityContainer container)
		{
			_container = container;
		}

		#region Члены IHttpControllerActivator

		public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			return (IHttpController)_container.Resolve(controllerType);
		}

		#endregion
	}
}