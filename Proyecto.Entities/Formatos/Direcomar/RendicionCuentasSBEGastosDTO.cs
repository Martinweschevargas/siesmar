using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Direcomar
{
    public partial class RendicionCuentasSBEGastosDTO
    {

        public int? RendicionCuentaSBEGastoId { get; set; }
        public int? AnioRendicionCuenta { get; set; }
        public int? NumeroMes { get; set; }
        public string? CodigoSubunidadEjecutora { get; set; }
        public string? ClasificacionGenericaGasto { get; set; }
        public string? DescClasificacionGenericaGasto { get; set; }
        public decimal? Entregado { get; set; }
        public decimal? Rendido { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? EncargadoInterno { get; set; }
        public decimal? GastoEncargo { get; set; }
        public decimal? EncargoOtorgado { get; set; }

        public string? DescMes { get; set; }
        public string? DescSubUnidadEjecutora { get; set; }

        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
