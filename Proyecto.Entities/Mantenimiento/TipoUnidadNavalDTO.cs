using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoUnidadNavalDTO
    {
        public int TipoUnidadNavalId { get; set; }
        public string? DescTipoUnidadNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
