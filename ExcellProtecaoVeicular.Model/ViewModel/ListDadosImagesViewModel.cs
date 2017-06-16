using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcellProtecaoVeicular.Model.Model;
namespace ExcellProtecaoVeicular.Model.ViewModel
{
    public class ListDadosImagesViewModel
    {
        public List<Image> Imagens { get; set; }
        public Clientes Cliente { get; set; }
        public Beneficios Beneficios { get; set; }
        public Veiculos Veiculos { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
