using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class MovilidadEscolarDTO
    {

        public int? MovilidadEscolarId { get; set; }
        public string? Fecha { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? CodigoMarcaVehiculo { get; set; }
        public int? AnioFabricacion { get; set; }
        public int? CapacidadTransporte { get; set; }
        public string? CodigoInstitucionEducativa { get; set; }
        public int? CantidadPersonasTransportadas { get; set; }
        public int? CargaId { get; set; }
        public string? DescInstitucionEducativa { get; set; }
        public string? ClasificacionVehiculo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
