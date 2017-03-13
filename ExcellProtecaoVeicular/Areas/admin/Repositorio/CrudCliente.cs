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

        // Cadastro
        public string CadastrarCliente(ClienteViewModel cliente)
        {
            string msg;

            if(cliente.Clientes == null)
            {
                return string.Format("Dados do cliente não foi informado");
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
        public string CadastarVeiculos(ClienteViewModel veiculos)
        {   
            
            if(veiculos.Veiculos == null)
            {
                return string.Format("Dados do Veiculo não informado");
            }
            try
            {
                enty.Veiculos.Add(veiculos.Veiculos);
                enty.SaveChanges();
                return string.Format("Dados do veiculo salvo com sucesso. \n {0}", veiculos.Veiculos.Placa);
            }
            catch (Exception ex)
            {

                return string.Format("Erro ao salvar os dados do veiculo \n Possivel erro: {0}", ex.Message);
            }
            
            
        }
        public string CadastrarEndereco(ClienteViewModel endereco)
        {

            if (endereco.Endereco == null)
            {
                return string.Format("Dados do endereco não foram informados.");
            }
            try
            {
                enty.Endereco.Add(endereco.Endereco);
                enty.SaveChanges();
                return string.Format("Dados do Endereço salvo com sucesso");
            }
            catch (Exception ex)
            {

                return string.Format("Não foi possível salvar o Endereco. \n Possivel erro: {0}", ex.Message);
            }
        }
        public string CadastrarBeneficios(ClienteViewModel beneficios)
        {
            if(beneficios.Beneficios== null)
            {
                return string.Format("Dados do Beneficios não foram informados.");
            }
            try
            {
                enty.Beneficios.Add(beneficios.Beneficios);
                enty.SaveChanges();
                return string.Format("Dados do Beneficios salvo com sucesso");
            }
            catch (Exception ex)
            {

                return string.Format("Não foi possível salvar os beneficios. \n Possivel erro: {0}",ex.Message);
            }
        }
        public string CadastrarTelefone(ClienteViewModel telefone)
        {
            if (telefone.Beneficios == null)
            {
                return string.Format("Dados do Telefone não foram informados.");
            }
            try
            {
                enty.Beneficios.Add(telefone.Beneficios);
                enty.SaveChanges();
                return string.Format("Dados do Telefone salvo com sucesso");
            }
            catch (Exception ex)
            {

                return string.Format("Não foi possível salvar os Telefone. \n Possivel erro: {0}", ex.Message);
            }
        }
        // Exclusão
        //Alteracao
    }
}