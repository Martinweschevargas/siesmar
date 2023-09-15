using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ResultadoInvestigacionDTO
    {
        public int ResultadoInvestigacionId { get; set; }
        public string? DescResultadoInvestigacion { get; set; }
        public string? CodigoResultadoInvestigacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
