using System.Web.Mvc;

namespace CoralCivet_Technology_Ecommerce_Website.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_loginAdmin",
                "Admin/loginAdmin",
                new { Controller = "Auth", action = "LoginAdmin", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Admin_logoutAdmin",
                "Admin/logoutAdmin",
                new { Controller = "Auth", action = "LogoutAdmin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller ="Dashboard", action = "Index", id = UrlParameter.Optional }, 
                new[] { "CoralCivet_Technology_Ecommerce_Website.Areas.Admin.Controllers" }
            );
        }
    }
}