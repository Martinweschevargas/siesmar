using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ResultadoTerminoSemestreDTO
    {
        public int ResultadoTerminoSemestreId { get; set; }
        public string? DescResultadoTerminoSemestre { get; set; }
        public string? CodigoResultadoTerminoSemestre { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
