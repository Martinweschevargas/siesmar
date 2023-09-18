using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diabaste
{
    public partial class DistribucionMaterialDTO
    {

        public int? DistribucionMaterialId { get; set; }
        public int? Anio { get; set; }
        public string?  NumeroMes { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoTipoMaterial { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public int? CantidadMaterialEntregado { get; set; }
        public string? FechaEntrega { get; set; }

        public string? DescMes { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescTipoMaterial { get; set; }
        public string? DescUnidadMedida { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}