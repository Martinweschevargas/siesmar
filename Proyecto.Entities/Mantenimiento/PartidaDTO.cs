using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PartidaDTO
    {
        public int PartidaId { get; set; }
        public string? DescPartida { get; set; }
        public string? CodigoPartida { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
