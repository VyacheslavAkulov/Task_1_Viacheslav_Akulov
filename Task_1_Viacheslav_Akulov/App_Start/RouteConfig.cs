using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task_1_Viacheslav_Akulov
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "", url: "games/new",
                defaults: new { controller = "Game", action = "Create" }
            );

            routes.MapRoute(
                name: "", url: "game/{gamekey}/newcomment",
                defaults: new { controller = "Comment", action = "NewComment" }
            );

            routes.MapRoute(
                name: string.Empty, url: "game/{gamekey}/comments",
                defaults: new { controller = "Comment", action = "GetCommnetsByGame" }
            );

            routes.MapRoute(
                name: "", url: "game/{gamekey}/download",
                defaults: new { controller = "Game", action = "Download" }
            );

            routes.MapRoute(
                name: "", url: "games/{action}/{gamekey}",
                defaults: new { controller = "Game" }
            );

            routes.MapRoute(
                name: "",
                url: "game/{key}",
                defaults: new { controller = "Game", action = "Details" }
                );

            routes.MapRoute(
                name: "",
                url: "games",
                defaults: new { controller = "Game", action = "GetGames", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Game", action = "GetGames", id = UrlParameter.Optional }
            );
        }
    }
}
