using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoActividadDenominacionDTO
    {
        public int TipoActividadDenominacionId { get; set; }
        public string? DescTipoActividadDenominacion { get; set; }
        public string? CodigoTipoActividadDenominacion { get; set; }
        public int TipoActividadId { get; set; }
        public string? DescTipoActividad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
