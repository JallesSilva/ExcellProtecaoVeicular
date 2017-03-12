using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcellProtecaoVeicular.Areas.admin.Models;
using ExcellProtecaoVeicular.Areas.admin.Repositorio;

namespace ExcellProtecaoVeicular.Areas.admin.Controllers
{
    
    [RoutePrefix("Administrador")]
    public class _adminController : Controller
    {
        CrudCliente crudCliente = null;

        [Authorize]
        [Route("Inicio")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Cadastro")]
        [Authorize]
        public ActionResult cadastrarClientes()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult cadastrarClientes(ClienteViewModel cadastrar)
        {
            crudCliente = new CrudCliente();
            TempData["message"] = crudCliente.CadastrarCliente(cadastrar);
            return View();
        }
    }

    
}