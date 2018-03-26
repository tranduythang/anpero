using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnperoFrontend
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
       name: "blogList3",
       url: "blog",
       defaults: new { controller = "Article", action = "Category", id = 0 }
       );
            routes.MapRoute(
            name: "blogList2",
            url: "blog/{title}-b{id}",
            defaults: new { controller = "Article", action = "Category", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "blogList",
              url: "{title}-b{id}",
              defaults: new { controller = "Article", action = "Category", id = UrlParameter.Optional },
              constraints: new { id = @"\d+", title = @"[^/]+" }
           );
            routes.MapRoute(
              name: "productDetail",
              url: "{title}-p{id}",
              defaults: new { controller = "product", action = "index", id = UrlParameter.Optional },
              constraints: new { id = @"\d+", title = @"[^/]+" }
           );
            routes.MapRoute(
              name: "search",
              url: "search",
              defaults: new { controller = "product", action = "search" }
           );
            routes.MapRoute(
             name: "category",
             url: "{title}-cat{id}",
             defaults: new { controller = "product", action = "category", id = UrlParameter.Optional },
             constraints: new { id = @"\d+", title = @"[^/]+" }
           );
            routes.MapRoute(
             name: "ParentCategory",
             url: "{title}-c{id}",
             defaults: new { controller = "product", action = "ParentCategory", id = UrlParameter.Optional },
             constraints: new { id = @"\d+", title = @"[^/]+" }
           );

            routes.MapRoute(
             name: "Article",
             url: "{title}-a{id}",
             defaults: new { controller = "article", action = "index", id = UrlParameter.Optional },
             constraints: new { id = @"\d+", title = @"[^/]+" }
           );
            routes.MapRoute(
                name: "chuyendoitiengviet",
                url: "chuyen-doi-tieng-viet",
                defaults: new { controller = "home", action = "chuyendoitiengviet" }
              );
            routes.MapRoute(
                name: "PaymentInfo",
                url: "PaymentInfo",
                defaults: new { controller = "home", action = "policy", type = 6 }
              );
            routes.MapRoute(
                name: "PrivacyPolicy",
                url: "PrivacyPolicy",
                defaults: new { controller = "home", action = "policy", type = 5 }
              );

            routes.MapRoute(
               name: "ProductReturnPolicy",
               url: "ProductReturnPolicy",
               defaults: new { controller = "home", action = "policy", type = 4 }
             );
            routes.MapRoute(
              name: "WarrantyRule",
              url: "WarrantyPolicy",
              defaults: new { controller = "home", action = "policy", type = 3 }
            );
            routes.MapRoute(
              name: "aboutRule",
              url: "about",
              defaults: new { controller = "home", action = "policy", type = 1 }
            );
            routes.MapRoute(
                name: "ShipPolicyRule",
                url: "shippolicy",
                defaults: new { controller = "home", action = "policy", type = 2 }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
