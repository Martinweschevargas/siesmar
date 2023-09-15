using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PersonalSolicitanteDTO
    {
        public int PersonalSolicitanteId { get; set; }
        public string? DescPersonalSolicitante { get; set; }
        public string? CodigoPersonalSolicitante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
