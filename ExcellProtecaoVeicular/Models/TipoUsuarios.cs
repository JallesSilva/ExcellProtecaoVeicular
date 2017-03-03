using System.ComponentModel.DataAnnotations;
namespace ExcellProtecaoVeicular.Models
{
    public class TipoUsuarios
    {
        [Key]
        public int IDTipoUsuario { get; set; }
        [Required]
        public string Tipo { get; set; }
        
}
}