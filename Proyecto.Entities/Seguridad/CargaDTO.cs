using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Seguridad
{
    public class CargaDTO
    {
        public int CodigoCarga { get; set; }
        public string? DescCarga { get; set; }
        public string? FechaCarga { get; set; }
        public int RegistrosCarga { get; set; }
    }
}
