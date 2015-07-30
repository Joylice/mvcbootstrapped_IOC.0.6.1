using System;
using System.Collections.Generic;
using System.Web.Mvc;

using MVCBootstrap.Web.Mvc.Navigations;

namespace MvcBootstrapped.WebUI.Infrastructure {

	public class TopNavigation : NavigationBase {
		private static List<NavigationItem> items = new List<NavigationItem> {
				new NavigationItem { Action = "Index", Controller = "Home", Title = "Home", Visibility = PageVisibility.Always },
				new NavigationItem { Action = "About", Controller = "Home", Title = "About", Visibility = PageVisibility.Always },
				new NavigationItem { Action = "ChangePassword", Controller = "Account", Title = "Change Password", Visibility = PageVisibility.Authenticated }
			};

		public override String Name {
			get {
				return "TopNavigation";
			}
		}

		protected override IEnumerable<NavigationItem> Items {
			get {
				return items;
			}
		}
	}
}