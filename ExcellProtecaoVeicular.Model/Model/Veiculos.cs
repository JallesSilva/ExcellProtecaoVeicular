using ExcellProtecaoVeicular.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExcellProtecaoVeicular.Model.Model
{
    public class Veiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDVeiculos { get; set; }
        public int? FK_Clientes { get; set; }
        [ForeignKey("FK_Clientes")]
        public Clientes Clientes { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        [Display(Name ="Tipo de Veiculos")]
        public EnumTiposDeVeiculos EnumTipoDeVeiculos { get; set; }


    }
}