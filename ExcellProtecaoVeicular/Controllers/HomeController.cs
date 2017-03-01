using System.Web.Mvc;
using ExcellProtecaoVeicular.Models;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Contato(_Email _objEmail)
        {
            if(ModelState.IsValid)
            {
                var body = "<p>Message: Testando</p>";
                var mail = new MailMessage();                
                mail.To.Add("excell - contabil@excellprotecaoveicular.com.br"); // para quem vai o e-mail
                mail.From = new MailAddress("no-replay@excellprotecaoveicular.com.br"); // De onde vem o e-mail
                mail.Subject = "Site - Excell Proteção Veicular"; // Titulo do E-mail
                mail.Body = body; // Corpo da mensagem
                mail.IsBodyHtml = true; // Transformando a mensagem em html
                var smtp = new SmtpClient();
                smtp.Host = "mail.excellprotecaoveicular.com.br";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("excell-contabil@excellprotecaoveicular.com.br", "131126Japa@");
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(mail);
                return RedirectToAction("Index");
            }
            return View(_objEmail);
          }
    }
}