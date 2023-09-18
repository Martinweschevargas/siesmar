using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadDependenciaDTO
    {
        public int UnidadDependenciaId { get; set; }
        public string? DescUnidadDependencia { get; set; }
        public string? CodigoUnidadDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
