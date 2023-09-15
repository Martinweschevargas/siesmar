using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dircomat
{
    public partial class ProcesoSeleccionContratacionDTO
    {
        public int ProcesoSeleccionContratacionId { get; set; }
        public string? NumeroMes { get; set; }
        public string? NroPAC { get; set; }
        public string? CodigoTipoSeleccion { get; set; }
        public string? CodigoEntidadConvocante { get; set; }
        public string? CodigoFuenteFinanciamiento { get; set; }
        public string? CodigoObjetoContratacion { get; set; }
        public string? CodigoMoneda { get; set; }
        public decimal? MontoProcesoSiacomar { get; set; }
        public string? CodigoSubUnidadEjecutora { get; set; }
        public string? CodigoAreaTecnica { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoMonedaReferencia { get; set;}
        public decimal? ValorReferencia { get; set; }
        public string? CodigoObservacionProceso { get; set; }
        public string? FechaConvocatoria { get; set; }
        public string? FechaBuenaPro { get; set; }
        public string? CodigoMonedaAdjudicado { get; set; }
        public decimal? MontoAdjudicado { get; set; }


        public string? DescMes { get; set; }
        public string? DescTipoSeleccion { get; set; }
        public string? DescEntidadConvocante { get; set; }
        public string? DescFuenteFinanciamiento { get; set; }
        public string? DescObjetoContratacion { get; set; }
        public string? DescMoneda { get; set; }
        public string? DescSubUnidadEjecutora { get; set; }
        public string? DescAreaTecnica { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescObservacionProceso { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
