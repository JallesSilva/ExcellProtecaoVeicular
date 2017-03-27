using System.ComponentModel.DataAnnotations;

namespace ExcellProtecaoVeicular.Model
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