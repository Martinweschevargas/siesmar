using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EstadoFase2EjecucionDTO
    {
        public int EstadoFase2EjecucionId { get; set; }
        public string? DescEstadoFase2Ejecucion { get; set; }
        public string? CodigoEstadoFase2Ejecucion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
