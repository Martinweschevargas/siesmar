using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class KilometroRecorridoUnidadTerrestreDTO
    {

        public int? KilometroRecorridoUnidadTerrestreId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public int? TipoVehiculoMovilId { get; set; }
        public int? MarcaVehiculoId { get; set; }
        public int? UnidadMovilTerrestreId { get; set; }
        public int? KmRecorridos { get; set; }
        public int? CombustibleConsumido { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescTipoVehiculoMovil { get; set; }
        public string? DescMarcaVehiculo { get; set; }
        public string? DescUnidadMovilTerrestre { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
