using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SituacionPersonalSolicitanteDTO
    {
        public int SituacionPersonalSolId { get; set; }
        public string? DescSituacionPersonalSol { get; set; }
        public string? CodigoSituacionPersonalSol { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
