using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAccionDTO
    {
        public int TipoAccionId { get; set; }
        public string? DescTipoAccion { get; set; }
        public string? CodigoTipoAccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
