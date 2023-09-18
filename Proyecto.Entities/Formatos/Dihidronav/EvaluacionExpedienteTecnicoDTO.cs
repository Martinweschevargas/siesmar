using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class EvaluacionExpedienteTecnicoDTO
    {

        public int? EvaluacionExpedienteTecnicoId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? CodigoTipoEstudio { get; set; }
        public string? DescripcionEstudio { get; set; }
        public string? DocumentoRespuesta { get; set; }
        public string? FechaTerminoEvaluacion { get; set; }
        public string? EmpresaPersonaSolicitante { get; set; }
        public string? EmpresaRealizaTrabajo { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CondicionEvaluacion { get; set; }
        public int? CargaId { get; set; }

        public string? DescTipoEstudio { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}