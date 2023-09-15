using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SeccionEstudioDTO
    {
        public int SeccionEstudioId { get; set; }
        public string? DescSeccionEstudio { get; set; }
        public string? CodigoSeccionEstudio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
