using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class ArchivoInversionTecnologicaDTO
    {
        public int ArchivoInversionTecnologicaId { get; set; }
        public string? CodigoAreaCT { get; set; }
        public string? TipoActividadInversionTec { get; set; }
        public string? DescAreaCT { get; set; }
        public decimal? FinanciamientoTPInversionTec { get; set; }
        public decimal? FinanciamientoRDRInversionTec { get; set; }
        public decimal? FinanciamientoTransferenciaInversionTec { get; set; }
        public int? CargaId { get; set; }

        public string? DescAreasCT { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
