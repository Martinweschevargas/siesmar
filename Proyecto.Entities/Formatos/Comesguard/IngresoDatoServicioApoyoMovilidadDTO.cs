using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comesguard
{
    public partial class IngresoDatoServicioApoyoMovilidadDTO
    {
        public int? IngresoDatoServicioApoyoMovilidadId { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoClaseVehiculo { get; set; }
        public string? CodigoMarcaVehiculo { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? CodigoEstadoOperativo { get; set; } 

        public string? DescDependencia { get; set; }
        public string? Clasificacion { get; set; }
        public string? ClasificacionVehiculo { get; set; }
        public string? DescEstadoOperativo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
