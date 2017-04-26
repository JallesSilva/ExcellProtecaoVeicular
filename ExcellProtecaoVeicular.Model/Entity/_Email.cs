using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcellProtecaoVeicular.Model.Entity
{
    public class _Email
    {
        [Required(ErrorMessage ="* Nome não informado")]        
        public string Nome { get; set; }
        [Required(ErrorMessage ="* Email não informado")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="* Telefone não informado")]
        [Phone]
        public string Telefone { get; set; }
        [Required(ErrorMessage ="* Mensagem não informado")]        
        public string Mensagem { get; set; }
        
    }
}