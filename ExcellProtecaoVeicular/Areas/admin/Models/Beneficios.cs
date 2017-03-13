using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcellProtecaoVeicular.Areas.admin.Models
{
    public class Beneficios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDBeneficios { get; set; }
        public int? FK_Cliente { get; set; }
        [ForeignKey("FK_Cliente")]
        public Clientes Cliente { get; set; }
        public bool Horas_Veiculos { get; set; }
        public bool HorasAgregados { get; set; }
        public bool Vidros { get; set; }
        public bool CarroReserva { get; set; }
        public EnumDias EnumDias { get; set; }
        public EnumFundo EnumFundo { get; set; }

    }
}