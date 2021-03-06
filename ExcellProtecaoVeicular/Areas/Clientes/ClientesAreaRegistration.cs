﻿using System.Web.Mvc;

namespace ExcellProtecaoVeicular.Web.Areas.Clientes
{
    public class ClientesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clientes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clientes_default",
                "Clientes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "ExcellProtecaoVeicular.Web.Areas.Clientes.Controllers" });

        }
    }
}