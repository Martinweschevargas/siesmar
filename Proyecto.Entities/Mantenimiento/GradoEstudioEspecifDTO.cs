using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GradoEstudioEspecifDTO
    {
        public int GradoEstudioEspecifId { get; set; }
        public string? DescGradoEstudioEspecif { get; set; }
        public string? CodigoGradoEstudioEspecif { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
