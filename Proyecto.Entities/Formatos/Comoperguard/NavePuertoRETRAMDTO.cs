using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class NavePuertoRETRAMDTO
    {

        public int? NavePuertoRETRAMId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? IndicativoLlamada { get; set; }
        public string? NombreBuque { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? TipoNaveId { get; set; }
        public string? NumeroOMI { get; set; }
        public string? AB { get; set; }
        public int? PaisProcedencia { get; set; }
        public string? FechaArribo { get; set; }
        public string? HoraArribo { get; set; }
        public int? PuertoPeruId { get; set; }
        public string? TiempoPermanencia { get; set; }
        public int? ProximosPuertos { get; set; }
        public int? TripulantesChilenos { get; set; }
        public int? TripulantesEcuatorianos { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescPuertoPeru { get; set; }

        public string? DescPaisProcedencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
