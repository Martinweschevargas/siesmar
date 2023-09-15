using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class ServicioMovilidadComestreDTO
    {

        public int? ServicioMovilidadComestreId { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public int? DependenciaId { get; set; }
        public int? ClaseVehiculoId { get; set; }
        public int? MarcaVehiculoId { get; set; }
        public string? Carroceria { get; set; }
        public string? PlacaRodaje { get; set; }
        public string? EstadoOperatividad { get; set; }


        public string? DescDependencia{ get; set; }
        public string? DescClaseVehiculo { get; set; }
        public string? DescMarcaVehiculo { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}