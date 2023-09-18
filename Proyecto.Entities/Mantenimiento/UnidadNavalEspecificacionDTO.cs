using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadNavalEspecificacionDTO
    {
        public int UnidadNavalEspecificacionId { get; set; }
        public string? DescUnidadNavalEspecificacion { get; set; }
        public string? CodigoUnidadNavalEspecificacion { get; set; }
        public int UnidadNavalTipoId { get; set; }
        public string? DescUnidadNavalTipo { get; set; }
        public string? nCasoUnidadNavalEspecificacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
