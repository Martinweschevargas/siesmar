using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MotivoViajeDTO
    {
        public int MotivoViajeId { get; set; }
        public string? DescMotivoViaje { get; set; }
        public string? CodigoMotivoViaje { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
