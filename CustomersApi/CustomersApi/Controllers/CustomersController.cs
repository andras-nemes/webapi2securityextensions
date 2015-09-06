using CustomersApi.Filters;
using CustomersApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CustomersApi.Controllers
{
	
	public class CustomersController : ApiController
	{
		[CustomAuthorizationFilter]
		public IHttpActionResult Get()
		{			
			HttpRequestContext httpRequestContext = Request.GetRequestContext();
			Debug.WriteLine(string.Format("Principal authenticated from extension method: {0}", httpRequestContext.Principal.Identity.IsAuthenticated));
			Debug.WriteLine(string.Format("Principal authenticated from shorthand property: {0}", RequestContext.Principal.Identity.IsAuthenticated));
			Debug.WriteLine(string.Format("Principal authenticated from User: {0}", User.Identity.IsAuthenticated));
			
			IList<Customer> customers = new List<Customer>();
			customers.Add(new Customer() { Name = "Nice customer", Address = "USA", Telephone = "123345456" });
			customers.Add(new Customer() { Name = "Good customer", Address = "UK", Telephone = "9878757654" });
			customers.Add(new Customer() { Name = "Awesome customer", Address = "France", Telephone = "34546456" });
			return Ok<IList<Customer>>(customers);
		}
	}
}