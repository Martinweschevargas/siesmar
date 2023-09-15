using System.ComponentModel.DataAnnotations.Schema;
namespace Marina.Siesmar.Entidades.Seguridad
{
    public class UsuarioDependenciaDTO
    {
        public int UsuarioDependenciaId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get;set; }
        public int Dependencia { get; set; }
        public string DescDependencia { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
