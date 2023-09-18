using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EstadoFase1FormEvalDTO
    {
        public int EstadoFase1FormEvalId { get; set; }
        public string? DescEstadoFase1FormEval { get; set; }
        public string? CodigoEstadoFase1FormEval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
