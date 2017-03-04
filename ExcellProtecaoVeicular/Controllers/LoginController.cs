using ExcellProtecaoVeicular.Models;
using ExcellProtecaoVeicular.Repositorio;
using System.Web.Mvc;
using System.Web.Security;


namespace ExcellProtecaoVeicular.Controllers
{
    public class LoginController : Controller
    {
        
        _EntyContext Enty = null;

        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("Brendon", false);
            return RedirectToAction("pagAdministrador");
        }       
        [Authorize(Roles ="admin")]
        public ActionResult pagAdministrador()
        {
            TempData["Nome"] = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public ActionResult cadastrarUsuarios(Usuarios user)
        {
             Enty = new _EntyContext();               
            Enty.Usuarios.Add(user);
            Enty.SaveChanges();
            TempData["MensagemCadUser"] = "Registro Salvo";
            user = null;            
            return View();
        }

        public ActionResult cadastrarUsuarios()
        {
            return View();
        }

        public ActionResult listarUsuario()
        {
            Enty = new _EntyContext();
            var users = Enty.Usuarios;
            return View(users);
        }
        
    }
}