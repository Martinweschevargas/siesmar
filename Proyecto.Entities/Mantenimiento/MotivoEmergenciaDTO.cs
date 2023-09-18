using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MotivoEmergenciaDTO
    {
        public int MotivoEmergenciaId { get; set; }
        public string? DescMotivoEmergencia { get; set; }
        public string? CodigoMotivoEmergencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
