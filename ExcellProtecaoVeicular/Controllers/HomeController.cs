using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellProtecaoVeicular.Controllers
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
            return View();
        }
        public ActionResult _HeaderNavBarMenu()
        {
            return View();
        }
        public ActionResult Associacao()
        {
            return View();
        }
        public ActionResult Beneficios()
        {
            return View();
        }
        public ActionResult Regulamento()
        {
            return View();
        }
        public ActionResult Contato()
        {
            return View();
        }
        
    }
}