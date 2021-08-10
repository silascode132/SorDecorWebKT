using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDecor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Login",
            //    url: "{controller}/dang-nhap",
            //    defaults: new { Controller = "User", action = "Login", id = UrlParameter.Optional }
            //    //namespaces: new[] { "WebDecor.Controllers" }
            //); 

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { Controller = "User", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { Controller = "User", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "cart",
                defaults: new { Controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { Controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetails",
                url: "product-details/{metatitle}-id",
                defaults: new { Controller = "Home", action = "ProductDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoryForCate",
                url: "product-cate/{metatitle}-id",
                defaults: new { Controller = "Home", action = "ProductForCate", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoryForPrice",
                url: "product-price/{metatitle}-id",
                defaults: new { Controller = "Home", action = "ProductForPrice", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Shop",
                url: "shop",
                defaults: new { Controller = "Home", action = "Shop", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ConfirmOrder",
                url: "confirm-order",
                defaults: new { Controller = "Order", action = "ConfirmOrder", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Order",
                url: "order",
                defaults: new { Controller = "Order", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "InfoOrder",
                url: "order-info/{metatitle}-id",
                defaults: new { Controller = "Order", action = "InfoOrder", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NotFound",
                url: "404notfound",
                defaults: new { Controller = "PageNotFound", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ChangePass",
                url: "change-pass",
                defaults: new { Controller = "Profile", action = "ChangedPass", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delivered",
                url: "delivered",
                defaults: new { Controller = "Profile", action = "Delivered", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Profile",
                url: "profile",
                defaults: new { Controller = "Profile", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MyOrder",
                url: "my-order",
                defaults: new { Controller = "Profile", action = "MyOrder", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Pending",
                url: "order-pending",
                defaults: new { Controller = "Profile", action = "PendingBill", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Shipping",
                url: "shipping",
                defaults: new { Controller = "Profile", action = "Shipping", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
