using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Seguridad
{
    public class DependenciaSubordinadoDTO
    {
        public int DependenciaSubordinadoId { get; set; }
        public string? Nombre { get; set; }
        public int NivelDependenciaId { get; set; }
        public string DescNivelDependencia { get; set; }
        public int DependenciaId { get; set; }
        public string NombreDependencia { get; set; }
        public string DescDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
