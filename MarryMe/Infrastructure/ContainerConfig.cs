namespace MarryMe.Infrastructure
{
	#region Using
	using System.Web.Http;
	using System.Web.Http.Dispatcher;
	using System.Web.Mvc;
	using Microsoft.Practices.Unity;
	using Microsoft.Practices.Unity.Configuration;
	#endregion

	/// <summary>
	/// Config to resolve web api data.
	/// </summary>
	public static class ContainerConfig
	{
		public static void Config()
		{
			var container = new UnityContainer();
			MapTypes(container);

			// Set resolver to WebApi.
			var httpControllerActivator = new UnityHttpControllerActivator(container);
			GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), httpControllerActivator);

			// Set resolver to MVC.
			var controllerActivator = new UnityControllerActivator(container);
			ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(controllerActivator));

		}

		private static void MapTypes(IUnityContainer container)
		{
			container.LoadConfiguration();
		}
	}
}