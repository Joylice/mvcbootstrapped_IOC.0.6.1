using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

using ApplicationBoilerplate.DependencyInjection;
using ApplicationBoilerplate.Logging;

using Localization;
using Localization.Configuration;

using MVCBootstrap.Web.Mvc.Navigations;
using MVCBootstrap.Web.Mvc.Services;

namespace MvcBootstrapped.WebUI.Infrastructure {

	public class SiteConfiguration : IDependencyBuilder {

		public void Configure(IDependencyContainer container) {
			container.RegisterPerRequest<INavigation, TopNavigation>();
			container.Register<ILogger, ASPNETTraceLog>();
		}

		public void ValidateRequirements(IList<ApplicationRequirement> feedback) { }
	}
}