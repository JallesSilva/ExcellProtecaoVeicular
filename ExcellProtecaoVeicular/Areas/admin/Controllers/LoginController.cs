using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExcellProtecaoVeicular.Repositorio;
using ExcellProtecaoVeicular.Models;
namespace ExcellProtecaoVeicular.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        //[Authorize(Roles ="admin")]
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

        public ActionResult cadastrarUsuarios(Usuarios user)
        {
             Enty = new _EntyContext();
            Enty.Usuarios.Add(user);
            return View();
        }
    }
}