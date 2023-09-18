using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SubUnidadEjecutoraDTO
    {
        public int SubUnidadEjecutoraId { get; set; }
        public string? DescSubUnidadEjecutora { get; set; }
        public string? CodigoSubUnidadEjecutora { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
