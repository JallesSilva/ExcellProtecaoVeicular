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
        private void CadastrarCliente(Clientes clientes)
        {  
            try
            {                
                enty.Clientes.Add(clientes);
                enty.SaveChanges();
                clientes.FK_Endereco = RelacionamentoDados.FKEndereco;
                clientes.FK_Telefone = RelacionamentoDados.FKTelefone;
                enty.Clientes.Attach(clientes);
                enty.Entry(clientes).State = EntityState.Modified;
                RelacionamentoDados.IDCliente = clientes.IDCliente;
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
            DadosViewModel.Clientes.Cpf = DadosViewModel.Clientes.Cpf.Replace('-', ' ').Replace('.', ' ');
            CadastrarCliente(DadosViewModel.Clientes);
            CadastarVeiculos(DadosViewModel.Veiculos);
            CadastrarBeneficios(DadosViewModel.Beneficios);
            
        }

        public Clientes deletarCliente(int id)
        {
            Clientes cliente = enty.Clientes.First(c => c.IDCliente == id);
            Telefone telefone = enty.Telefone.First(c => c.IDTelefone == cliente.FK_Telefone);
            Endereco endereco = enty.Endereco.First(c => c.IDEndereco == cliente.FK_Endereco);
            IQueryable<Veiculos> veiculos = enty.Veiculos.Where(c => c.FK_Clientes == cliente.IDCliente);
            IQueryable<Beneficios> beneficios = enty.Beneficios.Where(c => c.FK_Cliente == cliente.IDCliente);
            enty.Endereco.Remove(endereco);
            enty.Telefone.Remove(telefone);
            
            string strDiretorio = Path.Combine("~/App_Data/Imagens/"+cliente.IDCliente);

            foreach (var veiculo in veiculos)
            {
                enty.Veiculos.Remove(veiculo);
            
            }
            foreach (var beneficio in beneficios)
            {
            
                enty.Beneficios.Remove(beneficio);
                enty.Clientes.Remove(cliente);
                enty.SaveChanges();
            }
            if (File.Exists(strDiretorio))
            {
                File.Delete(strDiretorio);
            }
            else
                enty.SaveChanges();

            return cliente;
            
        }
    }
}