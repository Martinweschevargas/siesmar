using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diredumar
{
    public partial class SegEspecialidadPersonalSupSubDTO
    {
        public int SegEspecialidadPersonalSupSubId { get; set; }
        public string? CIPSegEspecialidad { get; set; }
        public string? DNISegEspecialidad { get; set; }
        public string? NombreSegEspecialidad { get; set; }
        public string? FechaNacimientoSegEspecialidad { get; set; }
        public string? SexoSegEspecialidad { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? TipoProgramaCapSegEspecialidad { get; set; }
        public string? NumericoPais { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoEscuela { get; set; }
        public string? MencionCursoSegEspecialidad { get; set; }
        public string? FinanciamientoSegEspecialidad { get; set; }
        public string? FechaInicioSegEspecialidad { get; set; }
        public string? FechaTerminoSegEspecialidad { get; set; }
        public string? FechaRegistroSegEspecialidad { get; set; }
        public int? HorasCapacitacionSegEspecialidad { get; set; }
        public string? CalificacionSegEspecialidad { get; set; }
        public string? CodigoMotivoTerminoCurso { get; set; }
        public int? CargaId { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? NombrePais { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? DescCodigoEscuela { get; set; }
        public string? DescMotivoTerminoCurso { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}

