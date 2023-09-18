using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dircapen
{
    public partial class IngresoDatosCapacitacionNavalDTO
    {

        public int? IngresoDatoCapacitacionNavalId { get; set; }
        public string? CIPPersonal { get; set; }
        public string? DNIPersonal { get; set; }
        public string? SexoPersonal { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoProgramaEspecializacionEspecifico { get; set; }
        public string? CodigoProgramaEspecializacionGrupo { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTemino { get; set; }
        public string? CodigoTipoModalidad { get; set; }
        public string? ConcluyoProgramaEstudios { get; set; }
        public int? TotalCredito { get; set; }
        public string? MotivosNoConcluir { get; set; }
        public decimal? CalificacionFinalObtenida { get; set; }
        public string? NombreDiploma { get; set; }


        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescProgramaEspecializacionEspecifico { get; set; }
        public string? DescProgramaEspecializacionGrupo { get; set; }
        public string? DescTipoModalidad { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
