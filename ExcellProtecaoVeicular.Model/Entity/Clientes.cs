using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExcellProtecaoVeicular.Model
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
        public int? FK_Endereco { get; set; }
        [ForeignKey("FK_Endereco")]
        public Endereco Endereco { get; set; }
        public int? FK_Telefone { get; set; }
        [ForeignKey("FK_Telefone")]
        public Telefone Telefone { get; set; }
        public string Email { get; set; }        
        
    }
}