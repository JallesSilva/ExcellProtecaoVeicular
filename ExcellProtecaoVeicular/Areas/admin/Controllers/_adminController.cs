using System.IO;
using ExcellProtecaoVeicular.Data.Repositorio;
using ExcellProtecaoVeicular.Model.Entity;
using System.Web.Mvc;
using System;

namespace ExcellProtecaoVeicular.Web.Areas.admin.Controllers
{
    public class _adminController : Controller
    {
        CrudCliente crudcliente = null;

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

        [Authorize]
        [HttpPost]
        public ActionResult cadastrarClientes(ClienteViewModel cadastrar)
        {
            crudcliente = new CrudCliente();
            crudcliente.CadastrarDados(cadastrar);
            int count = 0;
            try
            {
                foreach (string fileName in Request.Files)
                {
                    count++;
                    var  file = Request.Files[fileName];
                    var extensao = Path.GetExtension(file.FileName);
                    var fileNames = Path.GetFileName("IMG" + RelacionamentoDados.IDCliente+count +extensao);
                    var path = Path.Combine(Server.MapPath("~/App_Data"), fileNames);
                    file.SaveAs(path);
                }

                return View();
            }
            catch (Exception)
            {

                throw new Exception("Error ao salvar as imagens");
            }

            
            
        }

        [Authorize]
        public ActionResult listarClientes(Clientes listar)
        {
            crudcliente = new CrudCliente();
            var lista = crudcliente.listarClientes();
            Dispose(true);
            return View(lista);

        }

        [Authorize]
        public ActionResult deletarClientes(int id)
        {

            return View();
        }

        [Authorize]
        public ActionResult UploadImagem()
        {
            return PartialView();
        }

        
    }
}
