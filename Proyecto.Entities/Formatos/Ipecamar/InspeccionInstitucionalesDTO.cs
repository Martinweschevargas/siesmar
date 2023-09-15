using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ipecamar
{
    public partial class InspeccionInstitucionalesDTO
    {

        public int? InspeccionInstitucionalId { get; set; }
        public string? FechaInicioInspeccion { get; set; }
        public string? FechaTerminoInspeccion { get; set; }
        public int? DuracionInspeccion { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoNivelDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoInspeccionConocimiento { get; set; }
        public string? CodigoInspeccionExtension { get; set; }
        public string? CodigoInspeccionFinalidad { get; set; }
        public string? CodigoOrganoControlInspeccion { get; set; }
        public int? QInspectorParticipante { get; set; }
        public int? DeficienciaOperAdm { get; set; }
        public int? DeficienciaComunesOperAdm { get; set; }
        public int? ApreciacionOperAdm { get; set; }
        public int? ObservacionOperAdm { get; set; }
        public int? IrregularidadOperAdm { get; set; }
        public int? DeficienciaControlGestion { get; set; }
        public int? DeficienciaComunControlG { get; set; }
        public int? ApreciacionControlGestion { get; set; }
        public int? ObservacionControlGestion { get; set; }
        public int? IrregularidadControlGestion { get; set; }
        public int? DeficienciaPendOperAdm { get; set; }
        public int? DeficienciaComunPendOperAdm { get; set; }
        public int? ApreciacionPendOperAdm { get; set; }
        public int? ObservacionPendOperAdm { get; set; }
        public int? IrregularidadPendOperAdm { get; set; }
        public int? DeficienciaPendControlGestion { get; set; }
        public int? DeficienciaComunPendControlGestion { get; set; }
        public int? ApreciacionPendControlGestion { get; set; }
        public int? ObservacionPendControlGestion { get; set; }
        public int? IrregularidadPendControlGestion { get; set; }
        public int? DeficienciaSuperadaOperAdm { get; set; }
        public int? DeficienciaComunSuperadaOperAdm { get; set; }
        public int? ApreciacionSuperadaOperAdm { get; set; }
        public int? ObservacionSuperadaOperAdm { get; set; }
        public int? IrregularidadSuperadaOperAdm { get; set; }
        public int? DeficienciaSuperadaControlGestion { get; set; }
        public int? DeficienciaComunSuperadaControlGestion { get; set; }
        public int? ApreciacionSuperadaControlGestion { get; set; }
        public int? ObservacionSuperadaControlGestion { get; set; }
        public int? IrregularidadSuperadaControlGestion { get; set; }
        public int? FTotalDeficiencias { get; set; }
        public int? FTotalApreciaciones { get; set; }
        public int? FTotalObservaciones { get; set; }
        public int? FTotalIrregularidades { get; set; }
        public int? FTotalDeficienciaSuperadas { get; set; }
        public int? FTotalApreciacionSuperadas { get; set; }
        public int? FTotalObservacionSuperadas { get; set; }
        public int? FTotalIrregularidadSuperadas { get; set; }
        public int? FTotalDeficienciasPendientes { get; set; }
        public int? FTotalApreciacionesPendientes { get; set; }
        public int? FTotalObservacionPendientes { get; set; }
        public int? FTotalIrregularidadPendientes { get; set; }
        public int? CargaId { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescNivelDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescInspeccionConocimiento { get; set; }
        public string? DescInspeccionExtension { get; set; }
        public string? DescInspeccionFinalidad { get; set; }
        public string? DescOrganoControlInspeccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
