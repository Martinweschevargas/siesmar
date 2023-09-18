using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class EntregaArregloFloralCeremoniaDTO
    {

        public int? EntregaArregloFloralCeremoniaId { get; set; }
        public string? FechaAdquisicion { get; set; }
        public string? TipoArregloFloral { get; set; }
        public int? Cantidad { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public decimal? CostoUnitario { get; set; }
        public string? CodigoFrecuenciaDifusion { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }


        public string? DescUnidadMedida { get; set; }
        public string? DescFrecuenciaDifusion { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
