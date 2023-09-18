using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PosicionTipoArmaDTO
    {
        public int PosicionTipoArmaId { get; set; }
        public string? DescPosicionTipoArma { get; set; }
        public string? CodigoPosicionTipoArma { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
