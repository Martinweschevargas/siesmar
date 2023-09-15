using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class MillaNavegadaCombustibleHidrografiaDTO
    {

        public int? MillaNavegadaCombustibleHidrografiaId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? NumeroCascoUnidad { get; set; }
        public string? NumeroMes { get; set; }
        public decimal? Milla { get; set; }
        public decimal? Hora { get; set; }
        public decimal? CombustibleGalon { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescMes { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}