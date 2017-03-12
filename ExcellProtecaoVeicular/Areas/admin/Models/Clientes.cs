using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExcellProtecaoVeicular.Areas.admin.Models
{
    public class Clientes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public int Rg { get; set; }
        public DateTime DataNasci { get; set; }
        public string Cnh { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public string Email { get; set; }        
        
    }
}