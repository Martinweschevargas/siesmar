using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Seguridad
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public int? TipoDocumento { get; set; }
        public int? CalificacionId { get; set; }
        public int? TipoPersona { get; set; }
        public int? EspecialidadId { get; set; }
        public int? DependenciaId { get; set; }
        public int? RolId { get; set; }
        public int? GradoInstruccionId { get; set; }
        public string? Documento { get; set; }
        public string? Nombres { get; set; }
        public string? Nombre1 { get; set; }
        public string? Nombre2 { get; set; }
        public string? Nombre3 { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Sexo { get; set; }
        public string? Cip { get; set; }        
        public string? DescEspecialidad { get; set; }
        public string? DescCalificacion { get; set; }
        public string? FechaIngreso { get; set; }
        public string? UbigeoOldDomicilio { get; set; }
        public string? UbigeoDomicilio { get; set; }
        public string? CorreoInterno { get; set; }
        public string? CorreoExterno { get; set; }
        public string? TelefonoFijo { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? DescDependencia { get; set;}
        public string? DescGradoInstruccion { get; set; }
        public string? Foto { get; set; }
        public string? DescRol { get; set; }
        public string? user { get; set; }
        public string? pass { get; set; }

        [NotMapped]
        public bool MantenerActivo { get; set; }
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
