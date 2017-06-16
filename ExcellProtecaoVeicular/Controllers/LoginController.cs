using ExcellProtecaoVeicular.Model.Model;
using ExcellProtecaoVeicular.Data.Context;
using System.Web.Mvc;
using System.Web.Security;
using ExcellProtecaoVeicular.Model.Enum;
using ExcellProtecaoVeicular.Data.Repositorio;


namespace ExcellProtecaoVeicular.Web.Controllers
{
    public class LoginController : Controller
    {
        
        _EntyContext Enty_ = new _EntyContext();

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
       
        [Route("Logar")]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [Route("Logar")]
        public ActionResult Login(Usuarios usuarios)
        {            
            LoginRepositorio loginRepositorio = new LoginRepositorio();               
            if (usuarios.Nome == null && usuarios.password ==null)
                {
                ViewData["log"] = "Usuario ou senha invalido.";
                return View();

            }
            else if (usuarios.TipoUsuario == EnumTipoUsuario.Administrador)
            {
                if(loginRepositorio.UsuarioAdministrador(usuarios))
                {
                    
                FormsAuthentication.SetAuthCookie(usuarios.Login, false);
                //Session["admin"].ToString();
                return RedirectToAction("Index", "_admin",new { area="admin"});
                }
                else
                { 
                    ViewData["log"] = "Usuario ou senha invalido.";
                    return View();
                }

            }
            else if(usuarios.TipoUsuario == EnumTipoUsuario.Cliente)
            {
                if(loginRepositorio.UsuarioCliente(usuarios))
                { 
                FormsAuthentication.SetAuthCookie(usuarios.Login, false);
                return RedirectToAction("Index", "_cliente", new { area="cliente"});
                }
                else
                { 
                    ViewData["log"] = "Usuario ou senha invalido.";
                    return View();
                }
            }
            else
            {
                ViewData["log"] = "Tipo de Usuario não selecionado";
                return View();
            }
            
        }

        
    }
}