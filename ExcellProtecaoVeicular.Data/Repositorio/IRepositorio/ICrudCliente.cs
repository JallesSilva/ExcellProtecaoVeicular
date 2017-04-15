using System.Collections.Generic;
using ExcellProtecaoVeicular.Model.Entity;
using System.Web;

namespace ExcellProtecaoVeicular.Data.Repositorio.IRepositorio
{
    public interface ICrudCliente
    {
        //Cadastrar
        void CadastrarDados(ClienteViewModel DadosViewModel);
        //int CadastrarCliente(Clientes clientes,RelacionamentoDados relacionamentoDeDados);
        //void CadastarVeiculos(Veiculos veiculos,RelacionamentoDados relacionamentoDeDados);
        //int CadastrarEndereco(Endereco endereco);
        //void CadastrarBeneficios(Beneficios beneficios,RelacionamentoDados relacionamentoDeDados);
        //int CadastrarTelefone(Telefone telefone);
        //Deletar
        void deletarCliente(Clientes cliente);
        List<Clientes> listarClientes();
        
    }
}
