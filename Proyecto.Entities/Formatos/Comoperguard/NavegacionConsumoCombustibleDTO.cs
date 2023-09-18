using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class NavegacionConsumoCombustibleDTO
    {

        public int? NavesExtranjerasCapturadasId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? CascoUnidadNaval { get; set; }
        public int? TipoUnidadNavalInterventoraId { get; set; }
        public int? TipoCombustibleComoperguardId { get; set; }
        public int? StockServicentroSaldop { get; set; }
        public int? StockTanque { get; set; }
        public int? StockTotal { get; set; }
        public int? AsignacionMes { get; set; }
        public int? EntregaOtrasUUGG { get; set; }
        public int? ConsumoTotal { get; set; }
        public int? SaldoTotalMes { get; set; }
        public int? StockServicentro { get; set; }
        public int? StockTanques { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? Hora { get; set; }
        public int? Milla { get; set; }
        public string? OficioReferencia { get; set; }
        public string? FechaReferenciaOficio { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescTipoUnidadNavalInterventora { get; set; }
        public string? DescTipoCombustibleComoperguard { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
