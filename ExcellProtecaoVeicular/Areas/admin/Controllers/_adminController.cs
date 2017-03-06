using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellProtecaoVeicular.Areas.admin.Controllers
{
    public class _adminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}