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
        //Listar
        public List<Clientes> listarClientes()
        {   
            try
            {
                enty = new _EntyContext();
                var listar = enty.Clientes.AsEnumerable().OrderBy(c => c.Nome);
                if(listar.Count() == 0)
                {
                    return null;
                }
                else
                return listar.ToList();
                enty.Dispose();
            }
            catch (NullReferenceException)
            {
                return null;
            }
            
        }
        //Cadastrar Dados dos Clientes
        public void CadastrarDados(ClienteViewModel DadosViewModel)
        {
            enty = new _EntyContext();
            RelacionamentoDados.FKTelefone = CadastrarTelefone(DadosViewModel.Telefone);
            RelacionamentoDados.FKEndereco = CadastrarEndereco(DadosViewModel.Endereco);
            DadosViewModel.Clientes.Cpf = DadosViewModel.Clientes.Cpf.Replace("-", "").Replace(".", "");            
            CadastrarCliente(DadosViewModel.Clientes);
            CadastarVeiculos(DadosViewModel.Veiculos);
            CadastrarBeneficios(DadosViewModel.Beneficios);
            enty.Dispose();
        }
        // Deletar Cliente
        public Clientes deletarCliente(int id)
        {
            try
            {
                enty = new _EntyContext();
                Clientes cliente = enty.Clientes.First(c => c.IDCliente == id);
                Telefone telefone = enty.Telefone.First(c => c.IDTelefone == cliente.FK_Telefone);
                Endereco endereco = enty.Endereco.First(c => c.IDEndereco == cliente.FK_Endereco);
                IQueryable<Veiculos> veiculos = enty.Veiculos.Where(c => c.FK_Clientes == cliente.IDCliente);
                IQueryable<Beneficios> beneficios = enty.Beneficios.Where(c => c.FK_Cliente == cliente.IDCliente);
                IQueryable<Image> images = enty.Imagens.Where(c => c.FK_Clientes == cliente.IDCliente);
                enty = new _EntyContext();
                foreach (var beneficio in beneficios)
                {
                    enty.Beneficios.Attach(beneficio);
                    enty.Beneficios.Remove(beneficio);
                }
                foreach (var veiculo in veiculos)
                {
                    enty.Veiculos.Attach(veiculo);
                    enty.Veiculos.Remove(veiculo);
                }
                foreach (var image in images)
                {
                    enty.Imagens.Attach(image);
                    enty.Imagens.Remove(image);
                }
                    enty.Clientes.Attach(cliente);
                    enty.Clientes.Remove(cliente);
                    enty.Endereco.Attach(endereco);
                    enty.Endereco.Remove(endereco);
                    enty.Telefone.Attach(telefone);
                    enty.Telefone.Remove(telefone);
                    enty.SaveChanges();
                    enty.Dispose();
                    return cliente;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                enty.Dispose();                
            }
               
        }
        public void GravarDadosImagens(string nomeDaImagem)
        {
            enty = new _EntyContext();
            try
            {
                Image image = new Image();
                image.NameImage = nomeDaImagem;
                image.FK_Clientes = RelacionamentoDados.IDCliente;
                enty.Imagens.Add(image);
                enty.SaveChanges();
                enty.Dispose();
            }
            catch (Exception)
            {

                throw new Exception("Erro");
            }
            
        }
        public ListDadosImages DetalhesCliente(int id)
        {
            ListDadosImages listDadosImagens = new ListDadosImages();
            enty = new _EntyContext();
            listDadosImagens.Cliente = enty.Clientes.First(m => m.IDCliente == id);
            listDadosImagens.Imagens = (from list in enty.Imagens
                                       where list.FK_Clientes == id
                                       select list).ToList();
            enty.Dispose();
            return listDadosImagens;
        }
       
    }
}