using System.ComponentModel.DataAnnotations;
using ExcellProtecaoVeicular.Model.Enum;

namespace ExcellProtecaoVeicular.Model.Model
{
    public class Usuarios
    {
        [Key]
        public int IDUsuarios { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        
        public EnumTipoUsuario TipoUsuario { get; set; }
    }
}