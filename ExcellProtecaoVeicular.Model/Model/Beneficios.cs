using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExcellProtecaoVeicular.Model.Enum;

namespace ExcellProtecaoVeicular.Model.Entity
{
    public class Beneficios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDBeneficios { get; set; }
        public int? FK_Cliente { get; set; }
        [ForeignKey("FK_Cliente")]
        public Clientes Cliente { get; set; }
        [Display(Name ="Horas Veiculos")]
        public bool Horas_Veiculos { get; set; }
        [Display(Name ="Horas Agregados")]
        public bool HorasAgregados { get; set; }
        [Display(Name ="Vidros 70%")]
        public bool Vidros { get; set; }
        [Display(Name ="Carro Reserva")]
        public bool CarroReserva { get; set; }
        [Display(Name ="Dias")]
        public EnumDias EnumDias { get; set; }
        [Display(Name ="Fundo")]
        public EnumFundo EnumFundo { get; set; }
        [Display(Name ="Fundos para Terceiros")]
        public bool FundoParaTerceiros { get; set; }
        [Display(Name ="Lista de carros de reserva")]
        public string ListaItensDeCarrosReserva { get; set; }
        
    }
}