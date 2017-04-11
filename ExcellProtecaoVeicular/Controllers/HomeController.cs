using System.Web.Mvc;
using System.ComponentModel;
using ExcellProtecaoVeicular.Data;
using ExcellProtecaoVeicular.Model.Entity;

namespace ExcellProtecaoVeicular.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [DisplayName("TestandoInicio")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _HeaderLayout()
        {
            return PartialView();
        }
        public ActionResult _HeaderNavBarMenu()
        {
            return PartialView();
        }
        public ActionResult Associacao()
        {
            return PartialView();
        }
        public ActionResult Beneficios()
        {
            return PartialView();
        }
        public ActionResult Regulamento()
        {
            return PartialView();
        }

        
        
        public ActionResult Contato()
        {
            return PartialView();
        }

        [HttpPost]        
        public ActionResult Contato(_Email _objEmail)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    HomeRepositorio repositorio = new HomeRepositorio();
                    repositorio.SetEmail("SemPath", "brendon.genssinger@gmail.com","Site - Excell Proteção Veicular.");
                    //excellprotecaoveicular@hotmail.com
                    TempData["MensagemSucesso"] = "Envio com sucesso";
                    return PartialView();
                }
                catch (System.Exception)
                {
                    TempData["MensagemError"] = "Mensagem não enviada";
                    return PartialView();
                }
                
            }
            return View("Index"); 
          }

        public ActionResult PaginaError()
        {
            return View() ;
        }

      
    }
}