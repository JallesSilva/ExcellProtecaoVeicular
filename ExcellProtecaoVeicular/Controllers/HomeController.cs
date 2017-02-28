using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcellProtecaoVeicular.Models;

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

        [HttpPost]
        public ViewResult Contato(_Email _objEmail)
        {
            if(ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("brendon.genssinger@gmail.com");
                mail.From = new MailAddress(_objEmail.Email);
                mail.Subject = _objEmail.Nome;
                mail.Body = @"<p>Testando E-amil<\p>";
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("brendon.genssinger@gmail.com", "1311261425");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _objEmail);
            }
            else
            {
                return View();
            }
        }
        
    }
}