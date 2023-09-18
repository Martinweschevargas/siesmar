using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MotivoServicioDTO
    {
        public int MotivoServicioId { get; set; }
        public string? DescMotivoServicio { get; set; }
        public string? CodigoMotivoServicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
