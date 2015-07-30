using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using ApplicationBoilerplate.Events;

using MVCBootstrap.Web.Mvc.Controllers;

using StackExchange.Profiling;

using MvcBootstrapped.WebUI.Infrastructure;

namespace MVCBootstrap.WebUI.Controllers {

	public class HomeController : LocalizedBaseController {
		private readonly IEventPublisher publisher;

		public HomeController(IEventPublisher publisher) {
			// Just to make sure dependency injection is working!
			this.publisher = publisher;
		}

		public ActionResult Index() {
			MiniProfiler.Current.Step("hep");

			ViewBag.Message = this.textManager.Get("Heading", ns: "Home.Index");

			this.publisher.Publish<AsyncTest>(new AsyncTest { Message = "Async tasks working!" });

			return View();
		}

		public ActionResult About() {
			return View();
		}
	}
}