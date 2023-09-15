using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ipecamar
{
    public partial class ReporteAcademiaServMilitarDTO
    {
        public int ReporteAcademiaServMilitarId { get; set; }
        public string? FechaRegistroReporteAcad { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoTemasAcademicos { get; set; }
        public int? EfectivoActualPerMarReporteAcad { get; set; }
        public int? ParticipantesReporteAcad { get; set; }
        public int? CargaId { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTemasAcademicos { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
