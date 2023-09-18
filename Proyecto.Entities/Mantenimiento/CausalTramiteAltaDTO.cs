using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CausalTramiteAltaDTO
    {
        public int CausalTramiteAltaId { get; set; }
        public string? DescCausalTramiteAlta { get; set; }
        public string? CodigoCausalTramiteAlta { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
