using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ditranav
{
    public partial class MantenimientoReparacionVehiculosDTO
    {
        public int MantenimientoReparacionVehiculoId { get; set; }
        public string? PlacaVehiculoMantenimiento { get; set; }
        public string? FechaIngresoMantenimiento { get; set; }
        public string? ClasificacionFlotaVehiculoM { get; set; }
        public string? CodigoMarcaVehiculo { get; set; }
        public int? AnioFabricacionVehiculoM { get; set; }
        public int? KilometrosVehiculoM { get; set; }
        public string? DependenciaVehiculoM { get; set; }
        public string? MotivoServicioVehiculo { get; set; }
        public string? FechaSalidaVehiculoM { get; set; }
        public string? RequerimientoRepuesto { get; set; }
        public decimal? CostoRepuestos { get; set; }
        public string? OrdenCompraServicio { get; set; }


        public string? ClasificacionVehiculo { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
