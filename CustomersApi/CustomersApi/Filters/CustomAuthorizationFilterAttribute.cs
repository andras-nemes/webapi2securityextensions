using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CustomersApi.Filters
{
	public class CustomAuthorizationFilterAttribute : AuthorizeAttribute
	{
		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			IPrincipal incomingPrincipal = actionContext.RequestContext.Principal;
			Debug.WriteLine(string.Format("Principal is authenticated at the start of IsAuthorized in CustomAuthorizationFilterAttribute: {0}", incomingPrincipal.Identity.IsAuthenticated));
			IPrincipal genericPrincipal = new GenericPrincipal(new GenericIdentity("Andras", "CustomIdentification"), new string[] { "Admin", "PowerUser" });
			actionContext.RequestContext.Principal = genericPrincipal;
			return true;
		}

		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			Debug.WriteLine("Running HandleUnauthorizedRequest in CustomAuthorizationFilterAttribute as principal is not authorized.");
			base.HandleUnauthorizedRequest(actionContext);
		}
	}
}