using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TrabajoSeñalizacionNauticaDTO
    {
        public int TrabajoSeñalizacionNauticaId { get; set; }
        public string? DescTrabajoSeñalizacionNautica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
