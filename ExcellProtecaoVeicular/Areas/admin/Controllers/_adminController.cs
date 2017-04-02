using System;
using System.Web.Mvc;
using ExcellProtecaoVeicular.Model;
using ExcellProtecaoVeicular.Data;
using System.IO;
using System.Web;

namespace ExcellProtecaoVeicular.Web.Areas.admin.Controllers
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

        public ActionResult UploadImagem()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult UploadImagem(ClienteViewModel cliente)
        {
            int arquivosSalvos = 0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase arquivo = Request.Files[i];

                //Salva o arquivo
                if(arquivo.ContentLength >0)
                {
                    var uploadPath = Server.MapPath("~/Content/Uploads");
                    string caminhoArquivos = Path.Combine(uploadPath, Path.GetFileName(arquivo.FileName));
                    arquivo.SaveAs(caminhoArquivos);
                    arquivosSalvos++;
                }
            }
            ViewData["Message"] = String.Format("{0} arquivo(s) salvos com sucesso.", arquivosSalvos);
            return View("Upload");
        }
        
    }

    
}