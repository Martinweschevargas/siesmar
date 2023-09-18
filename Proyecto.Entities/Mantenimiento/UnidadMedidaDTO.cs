using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadMedidaDTO
    {
        public int UnidadMedidaId { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public string? DescUnidadMedida { get; set; }
        public string? AbrevUnidadMedida { get; set; }

        public int? FlagUnidadMedida { get;set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
