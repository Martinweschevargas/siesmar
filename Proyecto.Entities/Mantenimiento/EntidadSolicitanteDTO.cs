using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EntidadSolicitanteDTO
    {
        public int EntidadSolicitanteId { get; set; }
        public string? DescEntidadSolicitante { get; set; }
        public string? CodigoEntidadSolicitante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
