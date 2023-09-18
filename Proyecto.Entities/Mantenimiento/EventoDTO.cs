using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EventoDTO
    {
        public int EventoId { get; set; }
        public string? DescEvento { get; set; }
        public string? CodigoEvento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
