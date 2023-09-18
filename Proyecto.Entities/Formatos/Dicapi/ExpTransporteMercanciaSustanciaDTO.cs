using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dicapi
{
    public partial class ExpTransporteMercanciaSustanciaDTO
    {

        public int? ExpTransporteMercanciaSustanciaId { get; set; }
        public int? NumeroDocumento { get; set; }
        public string? FechaIngresoSolicitud { get; set; }
        public string? CodigoDptoMercanciaPeligrosa { get; set; }
        public int? DocumentoExpedido { get; set; }
        public string? NombreNave { get; set; }
        public string? PropietarioNave { get; set; }
        public string? RazonSocial { get; set; }
        public string? CodigoClaseNave { get; set; }
        public string? MatriculaNave { get; set; }
        public string? NumericoPais { get; set; }
        public string? FechaAtencionSolicitud { get; set; }
        public string? DescDptoMercanciaPeligrosa { get; set; }
        public string? DescClaseNave { get; set; }
        public string? NombrePais { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}