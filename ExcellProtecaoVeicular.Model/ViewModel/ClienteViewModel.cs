using System.Web;
using ExcellProtecaoVeicular.Model.Model;
namespace ExcellProtecaoVeicular.Model.ViewModel
{
    public class ClienteViewModel
    {
        public Clientes Clientes { get; set; }
        public Beneficios Beneficios { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public Veiculos Veiculos { get; set; }
        public Image Imagens { get; set; }
        
    }
}