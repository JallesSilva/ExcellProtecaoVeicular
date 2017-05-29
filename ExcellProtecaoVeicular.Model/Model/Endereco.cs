using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ExcellProtecaoVeicular.Model.Enum;
namespace ExcellProtecaoVeicular.Model.Entity
{
    public class Endereco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDEndereco { get; set; }
        public string Rua { get; set; }
        public string Quadra { get; set; }
        public string Lote { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public EnumUF UF { get; set; }
        
    }
}