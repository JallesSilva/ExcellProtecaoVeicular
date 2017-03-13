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
            TempData["messageTelefone"] = crudCliente.CadastrarTelefone(cadastrar);
            TempData["messageEndereco"] = crudCliente.CadastrarEndereco(cadastrar);
            TempData["messageCliente"] = crudCliente.CadastrarCliente(cadastrar);
            TempData["messageVeiculos"] = crudCliente.CadastarVeiculos(cadastrar);
            TempData["messageBeneficios"] = crudCliente.CadastrarBeneficios(cadastrar);            
            return View();
        }
    }

    
}