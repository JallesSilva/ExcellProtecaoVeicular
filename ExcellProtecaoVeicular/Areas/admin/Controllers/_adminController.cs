using System.IO;
using ExcellProtecaoVeicular.Data.Repositorio;
using ExcellProtecaoVeicular.Model.Entity;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using ExcellProtecaoVeicular.Model.Enum;
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
            HomeRepositorio repositorioEnviarEmail = new HomeRepositorio();
            if (ModelState.IsValid)
            {
                crudcliente = new CrudCliente();
                crudcliente.CadastrarDados(cadastrar); // Cadastrar dados do cliente
                int count = 0; // Contador para a imagem.
                               // Verifica se gerou o id do cliente para colocarmos no nome da imagem.
                if (RelacionamentoDados.IDCliente != 0 || RelacionamentoDados.IDCliente <= 0)
                {
                    try
                    {
                        foreach (string fileName in Request.Files)
                        {
                            
                            var file = Request.Files[count];
                            var extensao = Path.GetExtension(file.FileName);
                            var NovoNomeImagem = Path.GetFileName("IMG" + RelacionamentoDados.IDCliente + count + extensao);
                            crudcliente.GravarDadosImagens(NovoNomeImagem);
                            var strCaminhoDiretorio = "~/images/CarroDeClientes";
                            var path = Path.Combine(Server.MapPath(strCaminhoDiretorio), NovoNomeImagem);
                            file.SaveAs(path);
                            count++;
                        }
                        repositorioEnviarEmail.SetEmail(
                            "Nada", cadastrar.Clientes.Email, "Excell Protecao Veicular", null, EnumTipoUsuario.Administrador, cadastrar.Clientes);
                        ModelState.Clear();
                        return View();

                    }
                    catch (Exception)
                    {
                        TempData["ImagemError"] = "Erro ao salvar os dados, contate o administrador.";
                        return View();
                    }
                }
                else
                    TempData["ImagemError"] = "Não foi possível salvar a imagem";

                return View();
            }
            else
                TempData["DadosIncompletos"] = "Dados incompletos, por favor verificar.";
                return View();

        }

        [Authorize]
        public ActionResult listarClientes(Clientes listar)
        {
            crudcliente = new CrudCliente();
            var lista = crudcliente.listarClientes();
            if (lista ==null)
            {
                TempData["Mensagem"] = "Nenhum cliente encontrado";
                return RedirectToAction("PageError");
            }
            Dispose(true);
            return View(lista);

        }
        [Authorize]
        [HttpPost]
        public JsonResult deletarClientes(int IDCliente)
        {
            CrudCliente exclusao = new CrudCliente();
            Clientes cliente = exclusao.deletarCliente(IDCliente);
            return Json(string.Format("Cliente excluido com sucesso! Nome: {0} Número de identificação: {1}", cliente.Nome, cliente.IDCliente, JsonRequestBehavior.AllowGet));
        }
        [Authorize]
        public ActionResult UploadImagem()
        {

            return PartialView();
        }
        [Authorize]
        public ActionResult DetalhesDoCliente(int id)
        {   
            crudcliente = new CrudCliente();
            var dadosImagens = crudcliente.DetalhesCliente(id);
            return View(dadosImagens);
        }

        [Authorize]
        public ActionResult PageError()
        {
            return View();
        }
    }
}
