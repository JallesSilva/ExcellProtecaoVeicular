using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExcellProtecaoVeicular.Model
{
    public class Telefone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDTelefone { get; set; }
        public int DDD { get; set; }
        public int Tel_Casa { get; set; }
        public int Tel_Celular { get; set; }
        public int Tel_Recado { get; set; }        
    }
}