using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TrabajoRealizadoBienHistoricoDTO
    {
        public int TrabajoRealizadoBienHistoricoId { get; set; }
        public string? DescTrabajoRealizadoBienHistorico { get; set; }
        public string? CodigoTrabajoRealizadoBienHistorico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
