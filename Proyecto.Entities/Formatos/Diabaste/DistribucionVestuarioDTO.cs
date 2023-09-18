using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diabaste 
{ 
    public partial class DistribucionVestuarioDTO
{

        public int? DistribucionVestuarioId { get; set; }
        public int? Anio { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoTipoPrenda { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public int? CantidadPrendaEntregada { get; set; }
        public string? FechaEntrega { get; set; }

        public string? DescMes { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescTipoPrenda { get; set; }
        public string? DescUnidadMedida { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}