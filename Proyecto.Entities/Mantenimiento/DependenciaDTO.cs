using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DependenciaDTO
    {
        public int DependenciaId { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescDependencia { get; set; }
        public int NivelDependenciaId { get; set; }
        public string? DescNivelDependencia { get; set; }
        public string? CodigoDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
