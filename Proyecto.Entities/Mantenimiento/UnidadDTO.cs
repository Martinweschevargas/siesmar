using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadDTO
    {
        public int UnidadId { get; set; }
        public string? DescUnidad { get; set; }
        public string? CodigoUnidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
