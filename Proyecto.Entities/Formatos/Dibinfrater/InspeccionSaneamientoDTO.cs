using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dibinfrater
{
    public partial class InspeccionSaneamientoDTO
    {

        public int InspeccionSaneamientoId { get; set; }
        public string? SolicitudInspeccion { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CodigoSituacionLegal { get; set; }
        public int? AreaM2 { get; set; }
        public string? FechaInspeccion { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescSituacionLegal { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
