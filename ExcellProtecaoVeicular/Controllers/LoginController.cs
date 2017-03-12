using ExcellProtecaoVeicular.Models;
using ExcellProtecaoVeicular.Repositorio;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System;

namespace ExcellProtecaoVeicular.Controllers
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
            var user_pass =  (from us in Enty_.Usuarios
                            where us.Login.Equals(usuarios.Login) &&
                            us.password.Equals(usuarios.password)&& us.TipoUsuario == usuarios.TipoUsuario
                            select us).SingleOrDefault();

            if (user_pass == null)
                {
                ViewData["log"] = "Usuario ou senha invalido.";
                return View();

            }
            else if (usuarios.TipoUsuario== EnumTipoUsuario.administrador)
            {
                FormsAuthentication.SetAuthCookie(usuarios.Login, false);
                //Session["admin"].ToString();
                return RedirectToAction("Index", "_admin",new { area="admin"});
              
            }
            else if(usuarios.TipoUsuario == EnumTipoUsuario.cliente)
            {
                FormsAuthentication.SetAuthCookie(usuarios.Login, false);
                return RedirectToAction("Index", "_cliente", new { area="cliente"});
            }
            else { return View(); }
            
        }

        
    }
}