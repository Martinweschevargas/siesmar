using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AreaTecnicaDTO
    {
        public int AreaTecnicaId { get; set; }
        public string? DescAreaTecnica { get; set; }
        public string? CodigoAreaTecnica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
