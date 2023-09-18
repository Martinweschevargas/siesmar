using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ResultadoEjercicioEducativoDTO
    {
        public int ResultadoEjercicioEducativoId { get; set; }
        public string? DescResultadoEjercicioEducativo { get; set; }
        public string? CodigoResultadoEjercicioEducativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
