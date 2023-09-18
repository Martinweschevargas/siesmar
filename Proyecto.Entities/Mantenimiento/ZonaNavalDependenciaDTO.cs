using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ZonaNavalDependenciaDTO
    {
        public int ZonaNavalDependenciaId { get; set; }
        public string? DescZonaNavalDependencia { get; set; }
        public string? CodigoZonaNavalDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
