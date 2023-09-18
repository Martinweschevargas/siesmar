using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Seguridad
{
    public class FormatoReporteSubordinadoDTO
    {
        public int FormatoReporteSubordinadoId { get; set; }
        public int FormatoReporteId { get; set; }
        public int DependenciaSubordinadoId { get; set; }
        public string NombreFormatoReporte { get; set; }
        public string DescDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
