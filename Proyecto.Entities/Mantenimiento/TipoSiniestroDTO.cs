using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoSiniestroDTO
    {
        public int TipoSiniestroId { get; set; }
        public string? DescTipoSiniestro { get; set; }
        public string? CodTipoSiniestro { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
