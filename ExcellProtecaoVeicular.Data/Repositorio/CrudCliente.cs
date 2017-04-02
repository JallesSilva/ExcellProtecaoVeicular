using System;
using System.Data.Entity;
using ExcellProtecaoVeicular.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace ExcellProtecaoVeicular.Data
{
    public class CrudCliente
    {
        _EntyContext enty = null;
         public CrudCliente()
        {
            enty = new _EntyContext();            
        }

        // Cadastro
        public int CadastrarCliente(ClienteViewModel cliente, Clientes _cliente)
        {
            

            if(cliente.Clientes == null)
            {
                return -1;
            }
            try
            {                
                enty.Clientes.Add(cliente.Clientes);                
                enty.SaveChanges();
                cliente.Clientes.FK_Endereco = (int)_cliente.FK_Endereco;
                cliente.Clientes.FK_Telefone = (int)_cliente.FK_Telefone;
                enty.Clientes.Attach(cliente.Clientes);
                enty.Entry(cliente.Clientes).State = EntityState.Modified;
                return cliente.Clientes.IDCliente;
            }
            catch (Exception)
            {
              
              return -1;      
            }
            
            
        }
        public int CadastarVeiculos(ClienteViewModel veiculos, Clientes _clientes)
        {   
            
            if(veiculos.Veiculos == null)
            {
                return -1;
            }
            try
            {
                enty.Veiculos.Add(veiculos.Veiculos);
                enty.SaveChanges();
                veiculos.Veiculos.FK_Clientes = _clientes.IDCliente;
                enty.Veiculos.Attach(veiculos.Veiculos);
                enty.Entry(veiculos.Veiculos).State = EntityState.Modified;
                enty.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return - 1;
            }
            
            
        }
        public int CadastrarEndereco(ClienteViewModel endereco)
        {

            if (endereco.Endereco == null)
            {
                return 0;
            }
            try
            {   
                
                enty.Endereco.Add(endereco.Endereco);
                enty.SaveChanges();

                return (int)endereco.Endereco.IDEndereco; 
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int CadastrarBeneficios(ClienteViewModel beneficios, Clientes _clientes)
        {
            if(beneficios.Beneficios== null)
            {
                return -1;
            }
            try
            {
                enty.Beneficios.Add(beneficios.Beneficios);
                enty.SaveChanges();
                beneficios.Beneficios.FK_Cliente = _clientes.IDCliente;
                enty.Beneficios.Attach(beneficios.Beneficios);
                enty.Entry(beneficios.Beneficios).State = EntityState.Modified;
                enty.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        public int CadastrarTelefone(ClienteViewModel telefone)
        {
            if (telefone.Beneficios == null)
            {
                return 0;
            }
            try
            {
                enty.Telefone.Add(telefone.Telefone);
                enty.SaveChanges();
                return (int)telefone.Telefone.IDTelefone;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        // Exclusão
        public Clientes deletarCliente(int id)
        {
            
            var _cliente = enty.Clientes.First(c => c.IDCliente == id);
            var _endereco = enty.Endereco.First(c => c.IDEndereco == _cliente.FK_Endereco);
            var _telefone = enty.Telefone.First(c => c.IDTelefone == _cliente.FK_Telefone);
            var _veiculos = enty.Veiculos.First(c => c.FK_Clientes == _cliente.IDCliente);
            var _beneficios = enty.Beneficios.First(c => c.FK_Cliente == _cliente.IDCliente);            
            enty.Beneficios.Attach(_beneficios);
            enty.Veiculos.Attach(_veiculos);
            enty.Telefone.Attach(_telefone);
            enty.Endereco.Attach(_endereco);
            enty.Clientes.Attach(_cliente);
            enty.SaveChanges();           
            return _cliente;
        }
        //Alteracao
        //Listar
        public List<Clientes> listarClientes()
        {            
            var listar = enty.Clientes.AsEnumerable().OrderBy(c=> c.Nome);
            return listar.ToList();
        }

        //public void CadastrarImagensCliente(ClienteViewModel imagens,Clientes Idclientes)
        //{
            
        //}
    }
}