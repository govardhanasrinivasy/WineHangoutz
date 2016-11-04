using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Routing;

namespace Hangout
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Stop IIS/Asp.Net breaking our routes
            RouteTable.Routes.RouteExistingFiles = true;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{objectId}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
