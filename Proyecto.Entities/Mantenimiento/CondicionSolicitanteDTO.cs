using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionSolicitanteDTO
    {
        public int CondicionSolicitanteId { get; set; }
        public string? DescCondicionSolicitante { get; set; }
        public string? CodigoCondicionSolicitante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
