using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoEvaluacionSocialDTO
    {
        public int TipoEvaluacionSocialId { get; set; }
        public string? DescTipoEvaluacionSocial { get; set; }
        public string? CodigoTipoEvaluacionSocial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
