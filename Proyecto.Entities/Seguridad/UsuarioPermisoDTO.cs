using System.ComponentModel.DataAnnotations.Schema;
namespace Marina.Siesmar.Entidades.Seguridad
{
    public class UsuarioPermisoDTO
    {
        public int UsuarioPermisoId { get; set; }
        public int UsuarioFormatoId { get; set; }
        public string? Usuario { get; set; }
        public string? Dependencia { get; set; }
        public string? DependenciaSubordinada { get; set; }
        public int PermisoId { get; set; }
        public int FormatoId { get; set; }
        public string? Formato { get; set; }
        public string? Permiso { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
