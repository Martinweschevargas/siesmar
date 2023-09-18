using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EstadoProcesoDTO
    {
        public int EstadoProcesoId { get; set; }
        public string? DescEstadoProceso { get; set; }
        public string? CodigoEstadoProceso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
