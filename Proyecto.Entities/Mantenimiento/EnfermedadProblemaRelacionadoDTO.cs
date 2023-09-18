using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EnfermedadProblemaRelacionadoDTO
    {
        public int EnfermedadProblemaRelacionadoId { get; set; }
        public string? DescEnfermedadProblemaRelacionado { get; set; }
        public string? CodigoEnfermedadProblemaRelacionado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
