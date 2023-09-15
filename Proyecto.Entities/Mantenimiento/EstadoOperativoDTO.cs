using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EstadoOperativoDTO
    {
        public int EstadoOperativoId { get; set; }
        public string? DescEstadoOperativo { get; set; }
        public string? CodigoEstadoOperativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
