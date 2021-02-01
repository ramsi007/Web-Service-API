using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebServiceApi_Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "Api WS Mohammed",
            routeTemplate: "api/ws/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }

            //routeTemplate: "api/ws/{controller}/{id}/{name}/{num}",
            //defaults: new { id = RouteParameter.Optional, name = RouteParameter.Optional,
            //num = RouteParameter.Optional } //ici : id est obligatoire

            );

            // ce code permet de 
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

        }
    }
}
