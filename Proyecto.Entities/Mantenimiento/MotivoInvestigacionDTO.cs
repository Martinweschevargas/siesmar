using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MotivoInvestigacionDTO
    {
        public int MotivoInvestigacionId { get; set; }
        public string? DescMotivoInvestigacion { get; set; }
        public string? CodigoMotivoInvestigacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
