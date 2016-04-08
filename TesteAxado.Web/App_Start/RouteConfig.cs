using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TesteAxado.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Rotas de Avaliação
            routes.MapRoute(
                name: "Avaliação",
                url: "avaliacao/{action}/{id}",
                defaults: new { controller = "Rating", action = "Index", id = UrlParameter.Optional }
            );
            #endregion

            #region Rotas de Transportadoras
            routes.MapRoute(
              name: "Transportadora Alterar",
              url: "transportadora/alterar/{id}",
              defaults: new { controller = "Carrier", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Transportadora Detalhes",
                url: "transportadora/detalhes/{id}",
                defaults: new { controller = "Carrier", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Transportadora Novo",
                url: "transportadora/novo/{id}",
                defaults: new { controller = "Carrier", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Transportadora",
                url: "transportadora/{action}/{id}",
                defaults: new { controller = "Carrier", action = "Index", id = UrlParameter.Optional }
            );
            #endregion

            #region Rotas de Usuário
            routes.MapRoute(
              name: "Usuario Alterar",
              url: "usuario/alterar/{id}",
              defaults: new { controller = "User", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Usuario Detalhes",
                url: "usuario/detalhes/{id}",
                defaults: new { controller = "User", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Usuario Sair",
                url: "usuario/sair",
                defaults: new { controller = "User", action = "Logout" }
            );

            routes.MapRoute(
                name: "Usuario Novo",
                url: "usuario/novo/{id}",
                defaults: new { controller = "User", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Usuario",
                url: "usuario/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
