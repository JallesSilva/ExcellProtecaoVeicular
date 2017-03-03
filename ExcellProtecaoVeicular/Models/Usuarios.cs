using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExcellProtecaoVeicular.Models
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
        public TipoUsuarios TipoUsuario { get; set; }
    }
}