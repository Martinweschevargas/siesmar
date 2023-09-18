using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadTipoAeronaveDTO
    {
        public int UnidadTipoAeronaveId { get; set; }
        public string? DescUnidadTipoAeronave { get; set; }
        public string? CodigoUnidadTipoAeronave { get; set; }
        public int TipoAeronaveId { get; set; }
        public string? DescTipoAeronave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
