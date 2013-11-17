using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudyIt.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GroupTests",
                url: "group/{groupId}/tests",
                defaults: new { controller = "Groups", action = "EmptyTestsList" },
                namespaces: new string[] { "StudyIt.Web.Controllers" }
            );

            routes.MapRoute(
                name: "GroupLessons",
                url: "group/{groupId}/lessons",
                defaults: new { controller = "Groups", action = "EmptyLessonsList" },
                namespaces: new string[] { "StudyIt.Web.Controllers" }
            );

            routes.MapRoute(
                name: "GrBecome",
                url: "group-admin/become/",
                defaults: new { controller = "GroupAdmin", action = "Become" },
                namespaces: new string[] { "StudyIt.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "StudyIt.Web.Controllers" }
            );
        }
    }
}