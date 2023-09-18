using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoEstudioInvestigacionDTO
    {
        public int TipoEstudioInvestigacionId { get; set; }
        public string? DescTipoEstudioInvestigacion { get; set; }
        public string? CodigoTipoEstudioInvestigacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
