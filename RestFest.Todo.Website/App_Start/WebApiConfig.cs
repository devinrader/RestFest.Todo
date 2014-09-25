using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using PointW.MediaTypes.Formatters.Hal;
using System.Web.Http.Cors;

namespace RestFest.Todo.Website
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
            config.Formatters.Clear();
            config.Formatters.Add(new HalJsonMediaTypeFormatter { Indent=true });
        }
    }
}
