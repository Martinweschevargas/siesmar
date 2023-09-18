using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoInvestigacionDTO
    {
        public int TipoInvestigacionId { get; set; }
        public string? DescTipoInvestigacion { get; set; }
        public string? CodigoTipoInvestigacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
