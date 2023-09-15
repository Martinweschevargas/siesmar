using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FinalidadPrestamoDTO
    {
        public int FinalidadPrestamoId { get; set; }
        public string? DescFinalidadPrestamo { get; set; }
        public string? CodigoFinalidadPrestamo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
