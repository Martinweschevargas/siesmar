using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class AtencionProtocolarAeropuertoCallaoDTO
    {

        public int? AtencionProtocolarAeropuertoCallaoId { get; set; }
        public string? FechaAdquisicion { get; set; }
        public string? CodigoTipoPresenteProtocolar { get; set; }
        public int? Cantidad { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public decimal? CostoUnitario { get; set; }
        public string? CodigoFrecuenciaDifusion { get; set; }

        public string? DescTipoPresenteProtocolar { get; set; }
        public string? DescUnidadMedida { get; set; }
        public string? DescFrecuenciaDifusion { get; set; }

        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
