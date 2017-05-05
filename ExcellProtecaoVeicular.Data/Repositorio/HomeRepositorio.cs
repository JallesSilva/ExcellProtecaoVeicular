using System.Net.Mail;
using System.Net;
using System;
using ExcellProtecaoVeicular.Model.Entity;
using ExcellProtecaoVeicular.Model.Enum;

namespace ExcellProtecaoVeicular.Data.Repositorio
{
    public class HomeRepositorio
    {

        public bool SetEmail(string ViewPath, string emailTO, string Subject, _Email email, EnumTipoUsuario tipoUser,Clientes cliente )
        {
            string body=" ";
            
            switch (tipoUser)
            {
                case EnumTipoUsuario.Cliente: // Cliente envia o e-mail para a base da excell proteção veicular.
                    body = "<h3><b>Nome do Cliente :</b></h3><p>{0}</p><br/><h3><b>Telefone :</b></h3> 	<p>{1}</p><br/><h3><b>Email :</b></h3>     <p>{2}</p><br/>  <h3><b>Messagem :</b></h3> 	<p>{3}</p>";
                    break;
                case EnumTipoUsuario.Administrador: // Após cadastrar o usuário, enviaremos um e-mail a eles.
                    body = "<h3>A Excell Protecao veicular</h3><br/><p> Olá {0}, acabamos de cadastrar os seus dados em nossa base de dados.</p><br/> <p> Criamos a sua conta, o seu usuário é {1} e a sua senha {2} </p>";
                    break;
                default:
                    break;
            }
            //var body = "<h3><b>Nome do Cliente :</b></h3><p>{0}</p><br/><h3><b>Telefone :</b></h3> 	<p>{1}</p><br/><h3><b>Email :</b></h3>     <p>{2}</p><br/>  <h3><b>Messagem :</b></h3> 	<p>{3}</p>";
            
            var mail = new MailMessage();
            mail.To.Add("brendon.genssinger@gmail.com");//(emailTO);// para quem vai o e-mail
            mail.From = new MailAddress("excell-contabil@excellprotecaoveicular.com.br"); // De onde vem o e-mail
            mail.Subject = Subject; // Titulo do E-mail
            // Corpo da mensagem
            if(EnumTipoUsuario.Cliente == tipoUser)
            mail.Body = string.Format(body.Trim(),email.Nome,email.Telefone,email.Email,email.Mensagem); // Corpo da mensagem
            else if(EnumTipoUsuario.Administrador == tipoUser)
            mail.Body = string.Format(body.Trim(),cliente.Nome,cliente.Cpf,cliente.Cpf); // Corpo da mensagem
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