using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MarcaVehiculoDTO
    {
        public int MarcaVehiculoId { get; set; }
        public string? ClasificacionVehiculo { get; set; }
        public string? CodigoMarcaVehiculo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
