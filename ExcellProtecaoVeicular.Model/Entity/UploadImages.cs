using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellProtecaoVeicular.Model.Entity
{
    public class UploadImages
    {
        public int IDArquivo { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string tipo { get; set; }
        public string Caminho { get; set; }
    }
}
