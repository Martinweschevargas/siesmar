using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EstadoFase3FuncionamientoDTO
    {
        public int EstadoFase3FuncionamientoId { get; set; }
        public string? DescEstadoFase3Funcionamiento { get; set; }
        public string? CodigoEstadoFase3Funcionamiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
