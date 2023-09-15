using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diabaste
{
    public class VentaProductoPanaderiaDTO
    {
        public int? VentaProductoPanaderiaId { get; set; }
        public string? FechaVenta { get; set; }
        public string? CodigoPuntoDistribucionPanificacion { get; set; }
        public string? CodigoProductoPanificacion { get; set; }
        public int? CantidadProducidaConsumida { get; set; }
        public int? CargaId { get; set; }
        public string? DescPuntoDistribucionPanificacion { get; set; }
        public string? DescProductoPanificacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
