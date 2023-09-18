using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SituacionLegalDTO
    {
        public int SituacionLegalId { get; set; }
        public string? DescSituacionLegal { get; set; }
        public string? CodigoSituacionLegal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
