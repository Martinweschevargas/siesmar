using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ditranav
{
    public partial class VehiculoEmpleadoComisionDTO
    {
        public int VehiculoEmpleadoComisionId { get; set; }
        public string? PlacaVehiculoComision { get; set; }
        public string? ClasificacionFlotaComision { get; set; }
        public string? CodigoMarcaVehiculo { get; set; }
        public string? FechaComisionVehiculo { get; set; }
        public string? CodigoTipoVehiculoTransporte { get; set; }
        public string? DependenciaSolicitante { get; set; }


        public string? ClasificacionVehiculo { get; set; }
        public string? DescTipoVehiculoTransporte { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
