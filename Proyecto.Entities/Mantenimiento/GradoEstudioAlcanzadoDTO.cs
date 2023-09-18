using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GradoEstudioAlcanzadoDTO
    {
        public int GradoEstudioAlcanzadoId { get; set; }
        public string? DescGradoEstudioAlcanzado { get; set; }
        public string? CodigoGradoEstudioAlcanzado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
