using CustomersApi.OwinMiddleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CustomersApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			appBuilder.Use<SecurityComponent>();
		}
	}
}