using System;
using System.Web.Mvc;
using ExcellProtecaoVeicular.Model.Entity;
using ExcellProtecaoVeicular.Data;
using System.IO;
using System.Web;
using System.Linq;
using System.Collections.Generic;



namespace ExcellProtecaoVeicular.Web.Areas.admin.Controllers
{
    
    
    public class _adminController : Controller
    {
        CrudCliente crudCliente = null;

        [Authorize]        
        public ActionResult Index()
        {
            return View();
        }

    
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
                // Save imagens selecionadas.
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    var extensao = file.FileName.Substring(file.FileName.Length,3);
                    var fileNames = Path.GetFileName("IMG"+clientes.IDCliente+"."+extensao);
                    var path = Path.Combine(Server.MapPath("~/App_Data"), fileNames);
                    file.SaveAs(path);
                }

                //crudCliente.CadastrarImagensCliente(cadastrar, clientes);
                TempData["Mensagem"] = "Dados Salvo com sucesso";
                Dispose(true);
                return Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
                
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

        [Authorize]
        public ActionResult UploadImagem()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public virtual ActionResult UploadImagem(ClienteViewModel viewModel)
        {
            foreach (string fileName in Request.Files)
            {

                HttpPostedFileBase file = Request.Files[fileName];
                    var fileNames = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data"), fileNames);
                    file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Teste()
        {
            return View("Teste");
        }
        
        
        
    }

    
}