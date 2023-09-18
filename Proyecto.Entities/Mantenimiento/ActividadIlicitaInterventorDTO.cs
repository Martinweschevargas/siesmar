using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ActividadIlicitaInterventorDTO
    {
        public int ActividadIlicitaInterventorId { get; set; }
        public int CodUnidad { get; set; }
        public int ActividadIlicitaId { get; set; }
        public string? DescActividadIlicita { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
