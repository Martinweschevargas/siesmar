using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CausalBajaDTO
    {
        public int CausalBajaId { get; set; }
        public string? DescCausalBaja { get; set; }
        public string? CodigoCausalBaja { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
