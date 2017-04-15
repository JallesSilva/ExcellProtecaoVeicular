using System.Net.Mail;
namespace ExcellProtecaoVeicular.Data.Repositorio
{
    public class HomeRepositorio
    {

        public bool SetEmail(string ViewPath, string emailTO, string Subject)
        {
            var body = "<p>Message: Testando</p>";
            var mail = new MailMessage();
            mail.To.Add(emailTO);//("excell-contabil@excellprotecaoveicular.com.br"); // para quem vai o e-mail
            mail.From = new MailAddress("excell-contabil@excellprotecaoveicular.com.br"); // De onde vem o e-mail
            mail.Subject = Subject; // Titulo do E-mail
            mail.Body = body; // Corpo da mensagem
            mail.IsBodyHtml = true; // Transformando a mensagem em html
            var smtp = new SmtpClient();
            smtp.Host = "mail43.redehost.com.br";
            //smtp.Port = 587;            
            smtp.Credentials = new System.Net.NetworkCredential("excell-contabil@excellprotecaoveicular.com.br", "131126Japa@");
            smtp.EnableSsl = false;
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (SmtpException )
            {

                return false;
            }
                        
        }
    }
}