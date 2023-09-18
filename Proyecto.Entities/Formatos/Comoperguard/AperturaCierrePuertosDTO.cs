using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class AperturaCierrePuertosDTO
    {

        public int? AperturaCierrePuertoId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? Condicion { get; set; }
        public int? TipoPuertoPeruId { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? ResolucionCapitania { get; set; }
        public string? FechaResolucion { get; set; }
        public string? GFHMensajeNaval { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescTipoPuertoPeru { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
