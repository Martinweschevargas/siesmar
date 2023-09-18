using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class ActividadDifusionMaritimoDTO
    {
        public int ActividadDifusionMaritimoId { get; set; }
        public int? TipoActividadDifusionId { get; set; }
        public string? NombreActDifusionMar { get; set; }
        public string? AreaActDifusionMar { get; set; }
        public string? ResponsableActDifusionMar { get; set; }
        public string? InicioActDifusionMar { get; set; }
        public string? TerminoActDifusionMar { get; set; }
        public string? LugarActDifusionMar { get; set; }
        public int? QParticipanteActDifusionMar { get; set; }
        public int? QParticipanteEncuesta { get; set; }
        public int? QPreguntaEncuestaOBS { get; set; }
        public int? RptaCorrectasEncuenta { get; set; }
        public int? RptaIncorrectaEncuenta { get; set; }
        public int? PorcentRptaCorrectaEncuenta { get; set; }
        public string? DescTipoActividadDifusion { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
