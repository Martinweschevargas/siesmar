using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dibinfrater
{
    public partial class EvaluacionExpedienteTecnicoObraDTO
    {

        public int? EvaluacionExpedienteTecnicoObraId { get; set; }
        public string? NombreProyecto { get; set; }
        public string? CodigoSituacionExpedienteTecnico { get; set; }
        public string? CodigoTipoProceso { get; set; }
        public string? CodigoTipoProyecto { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public decimal? MontoContractual { get; set; }
        public string? FechaInicioEvaluacionProyecto { get; set; }
        public int? PorcentajeAvanceProyecto { get; set; }
        public string? DescSituacionExpedienteTecnico { get; set; }
        public string? DescTipoProceso { get; set; }
        public string? DescTipoProyecto { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
