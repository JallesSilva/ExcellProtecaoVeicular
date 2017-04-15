using System;
using System.Data.Entity;
using ExcellProtecaoVeicular.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ExcellProtecaoVeicular.Data.Context;
using ExcellProtecaoVeicular.Data.Repositorio.IRepositorio;
using System.Web;
using System.IO;


namespace ExcellProtecaoVeicular.Data.Repositorio
{
    public class CrudCliente : ICrudCliente
    {
        _EntyContext enty = null;
        
         public CrudCliente()
        {
            enty = new _EntyContext();            
        }
        //Cadastrar
        private void CadastrarCliente(Clientes cliente)
        {  
            try
            {                
                enty.Clientes.Add(cliente);
                enty.SaveChanges();
                cliente.FK_Endereco = RelacionamentoDados.FKEndereco;
                cliente.FK_Telefone = RelacionamentoDados.FKTelefone;
                enty.Clientes.Attach(cliente);
                enty.Entry(cliente).State = EntityState.Modified;
                RelacionamentoDados.IDCliente =  cliente.IDCliente;
                enty.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error ao cadastrar Cliente");      
            }
            
            
        }
        private void CadastarVeiculos(Veiculos veiculos)
        {
           try
            {
                veiculos.FK_Clientes = RelacionamentoDados.IDCliente;
                enty.Veiculos.Add(veiculos);
                enty.SaveChanges();
                //enty.Veiculos.Attach(veiculos);
                //enty.Entry(veiculos).State = EntityState.Modified;
                //enty.SaveChanges();
            }
            catch (Exception)
            {  throw new Exception("Não foi possível gravar os dados do Veiculo do cliente");       }
            
            
        }
        private int CadastrarEndereco(Endereco endereco)
        { 
            try
            {   
                enty.Endereco.Add(endereco);
                enty.SaveChanges();
                return (int)endereco.IDEndereco; 
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível gravar os dados do Endereço do cliente");
            }
        }
        private void CadastrarBeneficios(Beneficios beneficios)
        {
            try
            {
                beneficios.FK_Cliente = RelacionamentoDados.IDCliente;
                enty.Beneficios.Add(beneficios);
                enty.SaveChanges();
                //enty.Beneficios.Attach(beneficios);
                //enty.Entry(beneficios).State = EntityState.Modified;

            }
            catch (Exception)
            {
                throw new Exception("Erro, não foi possível gravar os beneficios dos dados do cliente");
            }
        }
        private int CadastrarTelefone(Telefone telefone)
        {  
            try
            {
                enty.Telefone.Add(telefone);
                enty.SaveChanges();
                return telefone.IDTelefone;
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível gravar os dados do telefone do cliente.");
            }
        }
       

     
        //Alteracao
        //Listar
        public List<Clientes> listarClientes()
        {            
            var listar = enty.Clientes.AsEnumerable().OrderBy(c=> c.Nome);
            return listar.ToList();
        }

        public void CadastrarDados(ClienteViewModel DadosViewModel)
        {   
            RelacionamentoDados.FKTelefone = CadastrarTelefone(DadosViewModel.Telefone);
            RelacionamentoDados.FKEndereco = CadastrarEndereco(DadosViewModel.Endereco);
            CadastrarCliente(DadosViewModel.Clientes);
            CadastarVeiculos(DadosViewModel.Veiculos);
            CadastrarBeneficios(DadosViewModel.Beneficios);
            
        }

        public void deletarCliente(Clientes cliente)
        {
            throw new NotImplementedException();
        }
    }
}