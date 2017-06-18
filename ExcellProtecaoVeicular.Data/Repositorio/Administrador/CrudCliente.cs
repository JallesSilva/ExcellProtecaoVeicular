using ExcellProtecaoVeicular.Data.Context;
using ExcellProtecaoVeicular.Data.Repositorio.Administrador.IRepositorio;
using ExcellProtecaoVeicular.Model.Model;
using ExcellProtecaoVeicular.Model.Class_Static;
using ExcellProtecaoVeicular.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;


namespace ExcellProtecaoVeicular.Data.Repositorio.Administrador
{
    public class CrudCliente : ICrudCliente
    {
       private _EntyContext enty = null;
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
                enty.Enderecos.Add(endereco);
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
                enty.Telefones.Add(telefone);
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
                Telefone telefone = enty.Telefones.First(c => c.IDTelefone == cliente.FK_Telefone);
                Endereco endereco = enty.Enderecos.First(c => c.IDEndereco == cliente.FK_Endereco);
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
                    enty.Enderecos.Attach(endereco);
                    enty.Enderecos.Remove(endereco);
                    enty.Telefones.Attach(telefone);
                    enty.Telefones.Remove(telefone);
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
        public ListDadosImagesViewModel DetalhesCliente(int id)
        {
            ListDadosImagesViewModel listDadosImagens = new ListDadosImagesViewModel();
            enty = new _EntyContext();
            listDadosImagens.Cliente = enty.Clientes.First(m => m.IDCliente == id);
            listDadosImagens.Imagens = (from list in enty.Imagens
                                       where list.FK_Clientes == id
                                       select list).ToList();
            listDadosImagens.Beneficios = enty.Beneficios.First(m => m.FK_Cliente == id);
            listDadosImagens.Veiculos = enty.Veiculos.First(m => m.FK_Clientes == id);
            listDadosImagens.Endereco = enty.Enderecos.First(m => m.IDEndereco == listDadosImagens.Cliente.FK_Endereco);
            listDadosImagens.Telefone = enty.Telefones.First(m => m.IDTelefone == listDadosImagens.Cliente.FK_Telefone);
            enty.Dispose();
            return listDadosImagens;
        }
       
    }
}