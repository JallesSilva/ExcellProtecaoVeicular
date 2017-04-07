using System;
using System.Web.Mvc;
using ExcellProtecaoVeicular.Model;
using ExcellProtecaoVeicular.Data;
using System.IO;


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
                for(int i=0;i<Request.Files.Count;i++)
                {
                    var imagem = Request.Files[i];  
                    imagem.SaveAs(Path.Combine(Server.MapPath("~/App_Data/Imagens"),imagem.FileName));
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
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult UploadImagem(HttpPostedFileBaseModelBinder imageFile)
        {

            return Json(imageFile, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Teste()
        {
            return View("Teste");
        }
        
        
        
    }

    
}