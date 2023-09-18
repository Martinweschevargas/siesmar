using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class ArriboNaveDTO
    {

        public int? ArriboNaveId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraArribo { get; set; }
        public int? DiaArribo { get; set; }
        public int? MesId { get; set; }
        public int? AnioArribo { get; set; }
        public int? PuertoPeruId { get; set; }
        public string? IndicativoNave { get; set; }
        public string? NombreNave { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? TipoNaveId { get; set; }
        public string? NumeroOMI { get; set; }
        public string? AB { get; set; }
        public string? AgenciaMaritima { get; set; }
        public int? PaisProcedencia { get; set; }
        public string? PuertoProcedencia { get; set; }
        public int? TripulantesChilenos { get; set; }
        public int? TripulantesEcuatorianos { get; set; }
        public int? TripulantesTotal { get; set; }
        public int? PasajerosChilenos { get; set; }
        public int? PasajerosEcuatorianos { get; set; }
        public int? PasajerosTotal { get; set; }
        public int? CantidadCargaDesembarcada { get; set; }
        public int? UnidadMedidaId { get; set; }
        public int? TipoCargaId { get; set; }
        public int? CantidadCargaPeligrosa { get; set; }
        public int? UnidadMedidaPeligrosa { get; set; }
        public int? TipoCargaPeligrosa { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? DescPuertoPeru { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescUnidadMedida { get; set; }
        public string? DescTipoCarga { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
