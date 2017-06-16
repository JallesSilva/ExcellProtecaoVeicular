using System.Collections.Generic;
using ExcellProtecaoVeicular.Model.Model;
using System.Web;
using ExcellProtecaoVeicular.Model.ViewModel;
namespace ExcellProtecaoVeicular.Data.Repositorio.Administrador.IRepositorio
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
        Clientes deletarCliente(int id);
        List<Clientes> listarClientes();
        
    }
}
