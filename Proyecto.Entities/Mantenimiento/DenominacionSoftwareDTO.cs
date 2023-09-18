using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DenominacionSoftwareDTO
    {
        public int DenominacionSoftwareId { get; set; }
        public string? DescDenominacionSoftware { get; set; }
        public string? CodigoDenominacionSoftware { get; set; }
        public string? DenominacionSoftware { get; set; }
        public int CategoriaSoftwareId { get; set; }
        public string? DescCategoriaSoftware { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
