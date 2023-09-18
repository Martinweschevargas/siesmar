using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diabaste
{
    public partial class RepuestoBuqueDTO
    {

        public int? RepuestoBuqueId { get; set; }
        public int? Anio { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoCondicion { get; set; }
        public string? NombreProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaSalida { get; set; }
        public int? TiempoCustodiaDia { get; set; }
        public int? CargaId { get; set; }
        public string? DescMes { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescCondicion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}