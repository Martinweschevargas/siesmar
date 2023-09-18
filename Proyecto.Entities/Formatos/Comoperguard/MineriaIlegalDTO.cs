using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class MineriaIlegalDTO
    {

        public int? MineriaIlegalId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? AreaIntervenida { get; set; }
        public string? RefMensajeNaval { get; set; }
        public string? HoraIntervencion { get; set; }
        public int? DiaIntervencion { get; set; }
        public int? MesId { get; set; }
        public int? AnioIntervencion { get; set; }
        public string? LatitudUbicacionNave { get; set; }
        public string? LongitudUbicacionNave { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? CascoUnidadNaval { get; set; }
        public int? SectorExtraInstitucionalId { get; set; }
        public int? TipoMaterialDestruidoId { get; set; }
        public int? CantidadPersonasDetenidas { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescSectorExtraInstitucional { get; set; }
        public string? DescTipoMaterialDestruido { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
