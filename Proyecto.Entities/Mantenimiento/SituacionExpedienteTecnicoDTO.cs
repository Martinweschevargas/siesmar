using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SituacionExpedienteTecnicoDTO
    {
        public int SituacionExpedienteTecnicoId { get; set; }
        public string? DescSituacionExpedienteTecnico { get; set; }
        public string? CodigoSituacionExpedienteTecnico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
