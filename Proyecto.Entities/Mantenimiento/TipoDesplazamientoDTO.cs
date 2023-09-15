using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoDesplazamientoDTO
    {
        public int TipoDesplazamientoId { get; set; }
        public string? DescTipoDesplazamiento { get; set; }
        public string? CodigoTipoDesplazamiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
