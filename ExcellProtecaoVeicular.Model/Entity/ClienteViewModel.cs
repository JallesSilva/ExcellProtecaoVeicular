﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcellProtecaoVeicular.Model
{
    public class ClienteViewModel
    {
        public Clientes Clientes { get; set; }
        public Beneficios Beneficios { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public Veiculos Veiculos { get; set; }
        
    }
}