using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

using ApplicationBoilerplate.DependencyInjection;
using ApplicationBoilerplate.Events;

using AConf = MVCBootstrap.Web.Events.AsynConfiguration;
using MVCBootstrap.Web.Events;

namespace MvcBootstrapped.WebUI.Infrastructure {

	public class AsyncConfiguration : IDependencyBuilder {

		public void Configure(IDependencyContainer container) {
			container.Register<IEventPublisher, EventPublisher>();
			container.Register<IEventListener, AsyncTestEventListener>();
			AConf aSyncConf = new AConf();
			aSyncConf.EndPoint = () => {
				return "async/execute";
			};
			aSyncConf.SiteUrl = () => {
				return ConfigurationManager.AppSettings["SiteURL"];
			};
			container.RegisterSingleton<IAsyncConfiguration>(aSyncConf);
			container.Register<IAsyncTask, AsyncWebTask>();
		}

		public void ValidateRequirements(IList<ApplicationRequirement> feedback) {
			if (ConfigurationManager.AppSettings["SiteURL"] == null) {
				feedback.Add(new ApplicationRequirement {
					Feedback = @"No site Url for the application, please insert this into the application's web.config file:

<configuration>
	<appSettings>
		<add key=""SiteURL"" value=""http://mysite"" />
	</appSettings>
</configuration>

Remember to replace the value with a value that matches your set-up.
",
					Level = RequirementLevel.Warning
				});
			}
			else {
				feedback.Add(new ApplicationRequirement { Feedback = "Site Url for the application located.", Level = RequirementLevel.Info });
			}
		}
	}
}