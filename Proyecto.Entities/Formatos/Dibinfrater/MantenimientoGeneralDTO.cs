using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dibinfrater
{
    public partial class MantenimientoGeneralDTO
    {

        public int? MantenimientoGeneralId { get; set; }
        public string? SolicitudMantenimiento { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? CodigoTipoMantenimiento { get; set; }
        public string? FechaInicioMantenimiento { get; set; }
        public string? FechaTerminoMantenimiento { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTipoMantenimiento { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
