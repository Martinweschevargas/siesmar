using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dipermar
{
    public partial class RecursosApelacionReconsideracionDTO
    {

        public int? RecursoApelacionReconsideracionId { get; set; }
        public string? NroDocumento { get; set; }
        public string? FechaDocumento { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaIngresoDocumento { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? TipoRecurso { get; set; }
        public string? CodigoAsuntoApelacionReconsideracion { get; set; }
        public string? DescripcionApelacion { get; set; }
        public string? CodigoResultadoApelacionReconsideracion { get; set; }
        public string? DocumentoResolutivo { get; set; }
        public string? FechaDocumentoResolutivo { get; set; }
        public string? FechaNotificacion { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescGrado { get; set; }
        public string? DescAsuntoApelacionReconsideracion { get; set; }
        public string? DescResultadoApelacionReconsideracion { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}