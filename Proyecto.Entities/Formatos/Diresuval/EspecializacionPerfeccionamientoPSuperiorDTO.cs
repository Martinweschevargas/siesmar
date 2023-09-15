using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresuval
{
    public partial class EspecializacionPerfeccionamientoPSuperiorDTO
    {

        public int? EspecializacionPerfeccionamientoId { get; set; }
        public string? DNIPersonalSuperior { get; set; }
        public int? EdadAnios { get; set; }
        public string? Sexo { get; set; }
        public string? Condicion { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? Procedencia { get; set; }
        public int? AnioPromocion { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoProgramaEspecializacionGrupo { get; set; }
        public string? CodigoProgramaEspecializacionEspecifico { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? FechaRegistro { get; set; }
        public string? ModalidadEspecializacion { get; set; }
        public string? ConcluyoPrograma { get; set; }
        public string? MotivoNoConcluir { get; set; }
        public decimal? CalificacionObtenida { get; set; }
        public string? CertificacionObtenido { get; set; }



        public string? DescEntidadMilitar { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescProgramaEspecializacionGrupo { get; set; }
        public string? DescProgramaEspecializacionEspecifico { get; set; }
        public int? CargaId { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
