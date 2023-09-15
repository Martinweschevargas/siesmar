using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diredumar
{
    public partial class CapacitacionPerfecDeberPSupSubDTO
    {
        public int CapacitacionPerfeccionamientoDeberId { get; set; }
        public string? CIPCapaPerfDeber { get; set; }
        public string? DNICapaPerfDeber { get; set; }
        public string? NombreCapaPerfDeber { get; set; }
        public string? FechaNacimientoCapaPerfDeber { get; set; }
        public string? SexoCapaPerfDeber { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? CapacitacioLineaCapaPerfDeber { get; set; }
        public string? InscripcionCapaPerfDeber { get; set; }
        public string? TipoProgramaCapaPerfDeber { get; set; }
        public string? NumericoPais { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoCodigoEscuela { get; set; }
        public string? MencionCursoCapacitacion { get; set; }
        public string? CodigoClasificacionCurso { get; set; }
        public string? FinanciamientoCapaPerfDeber { get; set; }
        public string? FechaInicioCapaPerfDeber { get; set; }
        public string? FechaTerminoCapaPerfDeber { get; set; }
        public string? FechaRegistroCapaPerfDeber { get; set; }
        public int? HoraCapacitacionCapaPerfDeber { get; set; }
        public string? CodigoMotivoTerminoCurso { get; set; }
        public int? CargaId { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? NombrePais { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? DescCodigoEscuela { get; set; }
        public string? DescClasificacionCurso { get; set; }
        public string? DescMotivoTerminoCurso { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
