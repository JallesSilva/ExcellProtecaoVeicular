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
            try
            {
                crudCliente = new CrudCliente();
                Clientes clientes = new Clientes();
                clientes.FK_Telefone = crudCliente.CadastrarTelefone(cadastrar);
                clientes.FK_Endereco = crudCliente.CadastrarEndereco(cadastrar);
                clientes.IDCliente = crudCliente.CadastrarCliente(cadastrar, clientes);
                crudCliente.CadastarVeiculos(cadastrar, clientes);
                crudCliente.CadastrarBeneficios(cadastrar, clientes);
                TempData["Mensagem"] = "Dados Salvo com sucesso";
                Dispose(true);
                return View();
            }
            catch (Exception)
            {
                TempData["Mensagem de Erro"] = "Não foi possivel salvar alguns dados.";

                return View();
            }
        }

        [Authorize]
        public ActionResult listarClientes(Clientes listar)
        {
            crudCliente = new CrudCliente();
            var lista = crudCliente.listarClientes();
            return View(lista);
            
        }
        

        [Authorize]
        public ActionResult deletarClientes(int id)
        {
            crudCliente = new CrudCliente();
            var cliente = crudCliente.deletarCliente(id);
            TempData["Cliente"] = cliente;
            return RedirectToAction("listarClientes");
        }
    }

    
}