using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ColorVehiculoDTO
    {
        public int ColorVehiculoId { get; set; }
        public string? DescColorVehiculo { get; set; }
        public string? CodigoColorVehiculo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
