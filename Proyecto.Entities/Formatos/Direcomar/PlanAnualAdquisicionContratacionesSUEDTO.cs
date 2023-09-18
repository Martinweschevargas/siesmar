using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Direcomar
{
    public partial class PlanAnualAdquisicionContratacionesSUEDTO
    {

        public int? PlanAnualAdquisicionContratacionId { get; set; }
        public int? AnioAdquisicion { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoSubunidadEjecutora { get; set; }
        public int? IncluidosAdquisicion { get; set; }
        public decimal? ImporteIncluidosAdquisicion { get; set; }
        public int? ConvocadosAdquisicion { get; set; }
        public decimal? ImporteConvocadosAdquisicion { get; set; }
        public int? ExcluidosAdquisicion { get; set; }
        public decimal? ImporteExcluidoAdquisicion { get; set; }
        public int? CargaId { get; set; }
        public string? DescMes { get; set; }
        public string? DescSubUnidadEjecutora { get; set; }
 
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
