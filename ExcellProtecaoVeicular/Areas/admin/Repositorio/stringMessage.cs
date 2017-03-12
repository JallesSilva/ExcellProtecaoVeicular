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
            DadosClientes(cliente);
        }        

        public stringMessages(Exception ex) { }
        public stringMessages() { }


        public static string CreateMessageSucessFull(ClienteViewModel cliente)
        {
            var msg_ = string.Format("Cliente {0} salvo com sucesso", cliente.Clientes.Nome.ToUpper());
            return msg_;
        }

        public static string DadosClientes(ClienteViewModel cliente)
        {
            var msg_ = string.Format("Cliente não foi informado");
            return msg_;
        }
    }
}