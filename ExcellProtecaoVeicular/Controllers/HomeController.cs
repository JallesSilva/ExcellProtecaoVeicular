using System.Web.Mvc;
using ExcellProtecaoVeicular.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using System.ComponentModel;
using ExcellProtecaoVeicular.Repositorio;

namespace ExcellProtecaoVeicular.Controllers
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

        
        [Route("Home/{TipoUsuario}")]
        public ActionResult Contato(string TipoUsuario)
        {
            if(TipoUsuario.Equals(""))

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
                    return Redirect(Url + "/#contact");
                }
                catch (System.Exception e)
                {
                    TempData["MensagemError"] = "Mensagem não enviada";
                    return Redirect(Url + "/#contact");
                }
                
            }
            return Redirect("Index"); 
          }

        public ActionResult PaginaError()
        {
            return View() ;
        }

      
    }
}