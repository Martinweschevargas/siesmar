using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadAeronaveDTO
    {
        public int UnidadAeronaveId { get; set; }
        public string? DescUnidadAeronave { get; set; }
        public string? CodigoUnidadAeronave { get; set; }
        public int TipoAeronaveId { get; set; }
        public string? DescTipoAeronave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
