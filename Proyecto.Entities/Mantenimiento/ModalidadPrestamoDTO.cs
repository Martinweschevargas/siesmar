using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModalidadPrestamoDTO
    {
        public int ModalidadPrestamoId { get; set; }
        public string? DescModalidadPrestamo { get; set; }
        public string? CodigoModalidadPrestamo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
