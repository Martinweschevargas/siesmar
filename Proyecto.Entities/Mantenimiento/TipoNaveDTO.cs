
using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
    {
        public class TipoNaveDTO
        {
            public int TipoNaveId { get; set; }
            public string? DescTipoNave { get; set; }

            [NotMapped]
            public string? UsuarioIngresoRegistro { get; set; }
        }
    }
