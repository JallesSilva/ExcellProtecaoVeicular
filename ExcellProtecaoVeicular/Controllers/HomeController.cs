using System.Web.Mvc;
using System.ComponentModel;
using ExcellProtecaoVeicular.Data.Repositorio;
using ExcellProtecaoVeicular.Model.Entity;
using ExcellProtecaoVeicular.Model.Enum;

namespace ExcellProtecaoVeicular.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
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
                    repositorio.SetEmail("SemPath", "excellprotecaoveicular@hotmail.com", "Site - Excell Proteção Veicular.", _objEmail,EnumTipoUsuario.Cliente,null);
                    TempData["MensagemSucesso"] = "Envio realizado com sucesso, em breve nossos consultores entrará em contato.";
                    //_objEmail = null;
                    Dispose(true);
                    //ModelState.Clear();
                    return Redirect("/Home/#contact");
                }
                catch (System.Exception)
                {
                    TempData["MensagemError"] = "Mensagem não enviada, tente novamente ou contate a empresa Excell Proteção Veicular.";
                    return Redirect("/Home/#contact");
                }
                
            }else
            {
                TempData["FalseModelState"] = "Possui algumas inconsistências de dados, por favor verificar.";
                return Redirect("/Home/#contact");
            }
        }

        public ActionResult PaginaError()
        {
            return View() ;
        }

      
    }
}