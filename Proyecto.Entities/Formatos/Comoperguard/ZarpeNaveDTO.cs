using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class ZarpeNaveDTO
    {

        public int? ZarpeNaveId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraZarpe { get; set; }
        public int? DiaZarpe { get; set; }
        public int? MesId { get; set; }
        public int? AnioZarpe { get; set; }
        public string? PuertoZarpe { get; set; }
        public string? IndicativoNave { get; set; }
        public string? NombreNave { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? TipoNaveId { get; set; }
        public string? NumeroOMI { get; set; }
        public string? AB { get; set; }
        public string? AgenciaMaritima { get; set; }
        public int? PaisProcedencia { get; set; }
        public string? PuertoProcedencia { get; set; }
        public int? TiempoEstimadoArriboHoras { get; set; }
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
        public int? CantidadCargaTransito { get; set; }
        public int? UnidadMedidaTransito { get; set; }
        public int? TipoCargaTransito { get; set; }
        public int? CantidadCargaPeligrosaTransito { get; set; }
        public int? UnidadMedidaPeligrosaTransito { get; set; }
        public int? TipoCargaPeligrosaTransito { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescUnidadMedida { get; set; }
        public string? DescTipoCarga { get; set; }
        public string? NombrePaisProcedencia { get; set; }
        public string? DescUnidadMedidaPeligrosa { get; set; }
        public string? DesceTipoCargaPeligrosa { get; set; }
        public string? DescUnidadMedidaTransito { get; set; }
        public string? DescTipoCargaTransito { get; set; }
        public string? DescUnidadMedidaPeligrosaTransito { get; set; }
        public string? DescTipoCargaPeligrosaTransito { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
