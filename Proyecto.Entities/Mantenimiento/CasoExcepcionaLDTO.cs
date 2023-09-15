using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CasoExcepcionalDTO
    {
        public int CasoExcepcionalId { get; set; }
        public string? DescCasoExcepcional { get; set; }
        public string? CodigoCasoExcepcional { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
