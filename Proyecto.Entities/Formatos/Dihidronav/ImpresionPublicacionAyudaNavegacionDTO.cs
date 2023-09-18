using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class ImpresionPublicacionAyudaNavegacionDTO
    {

        public int? ImpresionPublicacionAyudaNavegacionId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? CodigoProducto { get; set; }
        public int? HidronavNumero { get; set; }
        public string? FechaEmision { get; set; }
        public string? NumeroEdicion { get; set; }
        public int? CantidadProducida { get; set; }
        public string? CodigoFrecuencia { get; set; }
        public string? DescTipoProducto { get; set; }
        public string? DescFrecuencia { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}