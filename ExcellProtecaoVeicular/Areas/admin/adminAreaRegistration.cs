using System.Web.Mvc;

namespace ExcellProtecaoVeicular.Web.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrador",
                "Administrador/{action}/{id}",
                defaults: new { controller="_admin",action = "Index", id = UrlParameter.Optional }, namespaces: new[] {"ExcellProtecaoVeicular.Web.Areas.admin.Controllers" });
            
           
        }
    }
}