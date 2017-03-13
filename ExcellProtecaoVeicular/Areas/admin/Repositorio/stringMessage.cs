using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcellProtecaoVeicular.Areas.admin.Models;
namespace ExcellProtecaoVeicular.Areas.admin.Repositorio
{
    public class stringMessages
    {
        public stringMessages(ClienteViewModel cliente)
        {
            CreateMessageSucessFull(cliente);
            
        }        

        public stringMessages(Exception ex) { }
        public stringMessages() { }


        public static string CreateMessageSucessFull(ClienteViewModel ClienteViewModel)
        {
                
            var msg_ = string.Format("Cliente {0} salvo com sucesso", ClienteViewModel.Clientes.Nome.ToUpper());
            return msg_;
        }

      
        
    }
}