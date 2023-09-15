using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoInspeccionDTO
    {
        public int TipoInspeccionId { get; set; }
        public string? DescTipoInspeccion { get; set; }
        public string? CodigoTipoInspeccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
