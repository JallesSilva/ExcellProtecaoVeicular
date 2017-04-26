using System.IO;
using ExcellProtecaoVeicular.Data.Repositorio;
using ExcellProtecaoVeicular.Model.Entity;
using System.Web.Mvc;
using System;
using System.Net;
using System.Security.AccessControl;

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
            //crudcliente = new CrudCliente();
            //crudcliente.CadastrarDados(cadastrar);
            int count = 0;

            try
            {
                foreach (string fileName in Request.Files)
                {
                    count++;
                    var  file = Request.Files[fileName];
                    var extensao = Path.GetExtension(file.FileName);
                    var fileNames = Path.GetFileName("IMG" + RelacionamentoDados.IDCliente+count +extensao);
                    var strCaminhoDiretorio = "~/App_Data/Imagens/" + RelacionamentoDados.IDCliente;
                    var path = Path.Combine(Server.MapPath(strCaminhoDiretorio), fileNames);
                    //DirectoryInfo directory = new DirectoryInfo(strCaminhoDiretorio);
                    if (Directory.Exists(strCaminhoDiretorio))
                    {   
                        file.SaveAs(path);
                    }
                    else
                    {
                        var request = FtpWebRequest.Create(string.Format("ftp.excellprotecaoveicular.com.br/{0}", RelacionamentoDados.IDCliente));
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.Credentials = new NetworkCredential("excellprotecaoveicular.com.br", "131126Japa@");                        
                        file.SaveAs(path);
                    }
                    
                }

                return View();
            }
                catch (Exception ex)
            {
                
                throw new Exception("Error ao salvar as imagens" + ex.Message + " " + ex.InnerException);
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
        [HttpPost]
        public JsonResult deletarClientes(int IDCliente)
        {
            CrudCliente exclusao = new CrudCliente();
            Clientes cliente = exclusao.deletarCliente(IDCliente);
            return Json(string.Format("Cliente excluido com sucesso! Nome: {0} Número de identificação: {1}",cliente.Nome,cliente.IDCliente,JsonRequestBehavior.AllowGet));
        }



        [Authorize]
        public ActionResult UploadImagem()
        {
            
            return PartialView();
        }

        
    }
}
