using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudyIt.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "GroupsApi",
                routeTemplate: "api/groups/{id}",
                defaults: new { controller = "GroupsApi", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "CategoriesApi",
                routeTemplate: "api/categories/{id}",
                defaults: new { controller = "CategoriesApi", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "SubcategoriesApi",
                routeTemplate: "api/subcategories/{id}",
                defaults: new { controller = "SubcategoriesApi", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}