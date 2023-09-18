using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class NaveExtranjeraCapturadaDTO
    {

        public int? NavesExtranjerasCapturadasId { get; set; }
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
        public int? AmbitoNaveId { get; set; }
        public string? TenorInfracciones { get; set; }
        public string? ArticuloInfraccion { get; set; }
        public string? ProcesoAdministrativo { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescAmbitoNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
