using System.ComponentModel.DataAnnotations.Schema;
namespace Marina.Siesmar.Entidades.Seguridad
{
    public class UsuarioFormatoDTO
    {
        public int UsuarioFormatoId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get;set; }
        public int FormatoId { get; set; }
        public string DescFormato { get;set; }
        public string? DependenciaId { get; set; }
        public string? DependenciaSubordinadoId { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDependenciaSubordinado { get; set; }
        public int Flag { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
