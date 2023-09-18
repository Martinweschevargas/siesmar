using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class NavePeruanaCapturadaInternacionalDTO
    {

        public int? NavePeruanaCapturadaInternacionalId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraCaptura { get; set; }
        public int? DiaCaptura { get; set; }
        public int? MesId { get; set; }
        public int? AnioCaptura { get; set; }
        public string? NombreNave { get; set; }
        public string? MatriculaNave { get; set; }
        public int? TipoNaveId { get; set; }
        public int? CantidadTripulantes { get; set; }
        public int? CantidadPasajeros { get; set; }
        public int? AutoridadEmiteZarpeId { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public int? AmbitoNaveId { get; set; }
        public int? PuertoPeruId { get; set; }
        public int? PaisUbigeoId { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescAutoridadEmiteZarpe { get; set; }
        public string? DescAmbitoNaveo { get; set; }
        public string? DescPuertoPeru { get; set; }
        public string? NombrePais { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
