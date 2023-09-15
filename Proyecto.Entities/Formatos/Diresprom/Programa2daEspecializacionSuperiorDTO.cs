using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresprom
{
    public partial class Programa2daEspecializacionSuperiorDTO
    {

        public int? Programa2daEspecializacionSuperiorId { get; set; }
        public string? DNIPersonalSuperior { get; set; }
        public int? EdadPersonalSuperior { get; set; }
        public string? SexoPersonalSuperior { get; set; }
        public string? CondicionPersonalSuperior { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? ProcedenciaPersonalSuperior { get; set; }
        public int? AnioPromocionPersonalSuperior { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoProgramaEspecializacionGrupo { get; set; }
        public string? CodigoProgramaEspecializacionEspecifico { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? FechaRegistro { get; set; }
        public string? CodigoModalidadPrograma { get; set; }
        public string? ConcluyoProgramaEstudios { get; set; }
        public string? MotivosNoConcluir { get; set; }
        public decimal? CalificacionFinalObtenida { get; set; }
        public string? CertificacionTituloObtenido { get; set; }


        public string? DescEntidadMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescProgramaEspecializacionGrupo { get; set; }
        public string? DescProgramaEspecializacionEspecifico { get; set; }
        public string? DescModalidadPrograma { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
