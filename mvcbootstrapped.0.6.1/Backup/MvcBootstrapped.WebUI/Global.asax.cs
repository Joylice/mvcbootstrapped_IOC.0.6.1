using System.Web.Mvc;
using System.Web.Routing;

using ApplicationBoilerplate.DependencyInjection;

using MVCBootstrap;
using MVCBootstrap.DependencyInjection;
using MVCBootstrap.EntityFramework.DependencyInjection;
using MVCBootstrap.Ninject;

using MvcBootstrapped.WebUI.Infrastructure;

using StackExchange.Profiling;

namespace MvcBootstrapped.WebUI {
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication {

		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start() {
			/*
				Remember when changing the data access method (EF5, MongoDB, etc.) you also need
				to change the Membership and Role providers, and the connection strings in the
				app/web.config file!
			*/
			new ApplicationInitializer(
				new DependencyContainer(), new IDependencyBuilder[] {
						// Use the following line for Entity Framework, without profiling!
						new DataProviderBuilder(),
						// Use the following line for Entity Framework with profiling!
			            //new MVCBootstrap.Profiling.DataProviderBuilder(),
						// Use the following line for MongoDB
						//new MVCBootstrap.MongoDB.DependencyInjection.DataProviderBuilder(),
						new LocalizationBuilder(),
						new AsyncConfiguration(),
						new SiteConfiguration()
					});

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}
	}
}