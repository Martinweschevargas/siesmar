using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ObjetoContratacionDTO
    {
        public int ObjetoContratacionId { get; set; }
        public string? DescObjetoContratacion { get; set; }
        public string? CodigoObjetoContratacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
