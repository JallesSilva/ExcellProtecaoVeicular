using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExcellProtecaoVeicular.Model.Entity
{
    public class Telefone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDTelefone { get; set; }
        [Display(Name ="DDD")]
        public int DDD { get; set; }
        [Display(Name ="Casa")]
        public int Tel_Casa { get; set; }
        [Display(Name ="Celular")]
        public int Tel_Celular { get; set; }
        [Display(Name ="Recado")]
        public int Tel_Recado { get; set; }        
    }
}