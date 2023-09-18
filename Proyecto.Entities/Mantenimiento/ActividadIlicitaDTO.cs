using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ActividadIlicitaDTO
    {
        public int ActividadIlicitaId { get; set; }
        public string? CodigoActividadIlicita { get; set; }
        public string? DescActividadIlicita { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
