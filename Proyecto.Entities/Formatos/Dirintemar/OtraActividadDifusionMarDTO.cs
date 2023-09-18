using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class OtraActividadDifusionMarDTO
    {
        public int OtraActDifusionMarId { get; set; }
        public int? TipoActividadDifusionId { get; set; }
        public string? NombreOtraActDifusionMar { get; set; }
        public string? AreaOtraActDifusionMar { get; set; }
        public string? ResponsableOtraActDifusionMar { get; set; }
        public string? InicioOtraActDifusionMar { get; set; }
        public string? TerminoOtraActDifusionMar { get; set; }
        public string? LugarOtraActDifusionMar { get; set; }
        public int? DirigidoAId { get; set; }
        public int? QParticipanteOtraActDifusionMar { get; set; }
        public int? QParticipanteEncuestaOtra { get; set; }
        public int? QPreguntaEncuestaOtraOBS { get; set; }
        public int? RptaCorrectaEncuentaOtra { get; set; }
        public int? RptaIncorrectaEncuentaOtra { get; set; }
        public int? PorcentRptaCorrectaEncuentaOtra { get; set; }
        public string? DescTipoActividadDifusion { get; set; }
        public string? DescDirigidoA { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
