using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExcellProtecaoVeicular.Model.Entity
{
    public class Veiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDVeiculos { get; set; }
        public int? FK_Clientes { get; set; }
        [ForeignKey("FK_Clientes")]
        public Clientes Clientes { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }


    }
}