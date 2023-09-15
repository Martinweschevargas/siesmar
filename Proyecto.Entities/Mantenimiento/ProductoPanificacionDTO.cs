using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProductoPanificacionDTO
    {
        public int? ProductoPanificacionId { get; set; }
        public string? DescProductoPanificacion { get; set; }
        public string? CodigoProductoPanificacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
