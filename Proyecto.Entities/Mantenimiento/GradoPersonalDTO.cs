using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GradoPersonalDTO
    {
        public int GradoPersonalId { get; set; }
        public string? DescGradoPersonal { get; set; }
        public string? CodigoGradoPersonal { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? CodigoEntidadMilitar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
