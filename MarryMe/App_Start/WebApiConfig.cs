namespace MarryMe
{
	#region Using

	using System.Web.Http;

	#endregion

	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{

			//разрешить кросс доменные запросы
			config.EnableCors();

			// Конфигурация и службы веб-API

			// Маршруты веб-API
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
