using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class ZarpeRetornoNaveExtranjeraDTO
    {

        public int? ZarpeRetornoNaveExtranjeraId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraCaptura { get; set; }
        public int? DiaCaptura { get; set; }
        public int? MesId { get; set; }
        public int? AnioCaptura { get; set; }
        public string? NombreNaveExtranjera { get; set; }
        public string? MatriculaNaveExtranjera { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? TipoNaveId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? CascoUnidadNaval { get; set; }
        public int? PuertoPeruId { get; set; }
        public int? AmbitoNaveId { get; set; }
        public string? HoraArribo { get; set; }
        public int? DiaArribo { get; set; }
        public int? MesArribo { get; set; }
        public int? AnioArribo { get; set; }
        public string? PuertoDestino { get; set; }
        public int? PaisDestino { get; set; }
        public string? ETA { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMesa { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescPuertoPeru { get; set; }
        public string? DescAmbitoNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
