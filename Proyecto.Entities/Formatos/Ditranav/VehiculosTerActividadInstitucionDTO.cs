using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ditranav
{
    public partial class VehiculosTerActividadInstitucionDTO
    {
        public int VehiculosTerActividadInstitucionId { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? ClasificacionFlotaVehiculo { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoMarcaVehiculo { get; set; }
        public int? AnioFabricacionVehiculo { get; set; }
        public string? DependenciaAsignadaVehiculo { get; set; }
        public string? EstadoOperatividadVehiculo { get; set; }

        public string? DescZonaNaval { get; set; }
        public string? ClasificacionVehiculo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
