using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EntidadPublicaPrivadaDTO
    {
        public int EntidadPublicaPrivadaId { get; set; }
        public string? DescEntidadPublicaPrivada { get; set; }
        public string? CodigoEntidadPublicaPrivada { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
