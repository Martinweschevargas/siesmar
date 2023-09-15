using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DetalleInfraccionDTO
    {
        public int DetalleInfraccionId { get; set; }
        public string? DescDetalleInfraccion { get; set; }
        public string? CodigoDetalleInfraccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
