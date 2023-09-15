using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoVehiculoTransporteDTO
    {
        public int TipoVehiculoTransporteId { get; set; }
        public string? DescTipoVehiculoTransporte { get; set; }
        public string? CodigoTipoVehiculoTransporte { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
