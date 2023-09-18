using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoMantenimientoDTO
    {
        public int TipoMantenimientoId { get; set; }
        public string? DescTipoMantenimiento { get; set; }
        public string? CodigoTipoMantenimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
