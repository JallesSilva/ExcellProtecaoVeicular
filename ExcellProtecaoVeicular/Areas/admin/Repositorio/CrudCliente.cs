using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ExcellProtecaoVeicular.Repositorio;
using ExcellProtecaoVeicular.Areas.admin.Models;


namespace ExcellProtecaoVeicular.Areas.admin.Repositorio
{
    public class CrudCliente
    {
        _EntyContext enty = null;
        
        public CrudCliente()
        {
            enty = new _EntyContext();              
        }


        public string CadastrarCliente(ClienteViewModel cliente)
        {
            string msg;

            if(cliente.Clientes == null)
            {
                return stringMessages.DadosClientes(cliente).ToString();
            }
            try
            {
                enty.Clientes.Add(cliente.Clientes);
                enty.SaveChanges();                
                return stringMessages.CreateMessageSucessFull(cliente);
            }
            catch (Exception ex)
            {
              msg = string.Format("Não foi possivel salvar os dados, verifique por favor \n Possivel Causa do erro ; {0}", ex.Message);              
              return msg;      
            }
            
            
        }
    }
}