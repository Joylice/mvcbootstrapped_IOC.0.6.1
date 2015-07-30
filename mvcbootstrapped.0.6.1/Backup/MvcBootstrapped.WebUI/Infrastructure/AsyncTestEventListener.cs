using System;
using System.Web;
using System.Web.Caching;
using ApplicationBoilerplate.Events;

namespace MvcBootstrapped.WebUI.Infrastructure {

	public class AsyncTestEventListener : IAsyncEventListener<AsyncTest> {
		private readonly IAsyncTask task;

		public AsyncTestEventListener(IAsyncTask task) {
			this.task = task;
		}

		public void Queue(AsyncTest payload) {
			this.task.Execute(this, payload, 5);
		}

		public Boolean RunAsynchronously {
			get {
				return true;
			}
		}

		public void Handle(AsyncTest payload) {
			HttpContext.Current.Cache.Add("AsyncMessage", payload.Message, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
		}

		public void Handle(Object payload) {
			if (payload is AsyncTest) {
				this.Handle((AsyncTest)payload);
			}
			else {
				throw new ArgumentException("payload");
			}
		}

		public Boolean UniqueEvent {
			get {
				return true;
			}
		}

		public Byte Priority {
			get {
				return 0;
			}
		}
	}
}