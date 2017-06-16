using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcellProtecaoVeicular.Model.Model
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public int? FK_Clientes { get; set; }
        [ForeignKey("FK_Clientes")]
        public Clientes Clientes { get; set; }
        public string NameImage { get; set; }       
    }
}
