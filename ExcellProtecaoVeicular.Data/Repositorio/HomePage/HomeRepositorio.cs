using System.Net.Mail;
using System.Net;
using System;
using ExcellProtecaoVeicular.Model.Model;
using ExcellProtecaoVeicular.Model.Enum;

namespace ExcellProtecaoVeicular.Data.Repositorio
{
    public class HomeRepositorio
    {

        public bool SetEmail(string ViewPath, string emailTO, string Subject, _Email email, EnumTipoUsuario tipoUser,Clientes cliente )
        {
            string body="";
            var mail = new MailMessage();
            mail.To.Add(new MailAddress(emailTO));//(emailTO);// para quem vai o e-mail
            mail.From = new MailAddress("excell-contabil@excellprotecaoveicular.com.br"); // De onde vem o e-mail
            mail.Subject = Subject; // Titulo do E-mail
            switch (tipoUser)
            {
                case EnumTipoUsuario.Cliente: // Cliente envia o e-mail para a base da excell proteção veicular.
                    body = "<h3><b>Nome do Cliente :</b></h3><p>{0}</p><br/><h3><b>Telefone :</b></h3> 	<p>{1}</p><br/><h3><b>Email :</b></h3><p>{2}</p><br/><h3><b>Messagem :</b></h3><p>{3}</p>";
                    mail.Body = string.Format(body.Trim(), email.Nome.ToString(), email.Telefone.ToString(), email.Email.ToString(), email.Mensagem.ToString()); // Corpo da mensagem
                    break;
                case EnumTipoUsuario.Administrador: // Após cadastrar o usuário, enviaremos um e-mail a eles.
                    body = "<h3>A Excell Protecao veicular informa: </h3><br/><p> Parabéns {0} você acaba de se tornar um novo associado da Excell Proteção Veicular.</p>";
                    mail.Body = string.Format(body.Trim(), cliente.Nome.ToString()); // Corpo da mensagem
                    break;
                default:
                    break;
            }
            mail.IsBodyHtml = true; // Transformando a mensagem em html
            var smtp = new SmtpClient();
            smtp.Host = "mail35.redehost.com.br";
            smtp.Credentials = new NetworkCredential("excell-contabil@excellprotecaoveicular.com.br", "131126Japa@");
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