using System.Net.Mail;
using System.Net;
using System;
using ExcellProtecaoVeicular.Model.Entity;

namespace ExcellProtecaoVeicular.Data.Repositorio
{
    public class HomeRepositorio
    {

        public bool SetEmail(string ViewPath, string emailTO, string Subject, _Email email)
        {

            //var body = "<h3><b>Nome do Cliente :</b></h3><p>{0}</p><br/><h3><b>Telefone :</b></h3> 	<p>{1}</p><br/><h3><b>Email :</b></h3>     <p>{2}</p><br/>  <h3><b>Messagem :</b></h3> 	<p>{3}</p>";
            var body = "<h3><b>Nome do Cliente :</b> {0}</h3><p></p><br/><h3><b>Telefone :</b>{1}</h3> 	<p></p><br/><h3><b>Email :</b>{2}</h3>     <p></p><br/>  <h3><b>Messagem :</b>{3}</h3> 	<p></p>";
            var mail = new MailMessage();
            mail.To.Add(emailTO);//("excell-contabil@excellprotecaoveicular.com.br"); // para quem vai o e-mail
            mail.From = new MailAddress("excell-contabil@excellprotecaoveicular.com.br"); // De onde vem o e-mail
            mail.Subject = Subject; // Titulo do E-mail
            //mail.Body = string.Format(body, email.Nome, email.Telefone, email.Email, email.Mensagem); // Corpo da mensagem
            mail.Body = string.Format(body,email.Nome,email.Telefone,email.Email,email.Mensagem); // Corpo da mensagem
            mail.IsBodyHtml = true; // Transformando a mensagem em html
            var smtp = new SmtpClient();
            //smtp.Port = 587;            
            smtp.Credentials = new NetworkCredential("excell-contabil@excellprotecaoveicular.com.br", "131126Japa@");
            smtp.Host = "smtp.excellprotecaoveicular.com.br";
            smtp.EnableSsl = false;
            try
            {
                smtp.Send(mail);
                return true;
            }
                catch (SmtpException ex)
            {

                throw new Exception("Error "+ex.Message);
            }
                        
        }
    }
}