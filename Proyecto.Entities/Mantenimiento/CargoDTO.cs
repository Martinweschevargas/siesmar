using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CargoDTO
    {
        public int CargoId { get; set; }
        public string? DescCargo { get; set; }
        public string? CodigoCargo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
