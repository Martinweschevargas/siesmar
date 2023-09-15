using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzodos
{
    public partial class ServicioDispositivoSeguridadPrestadoDTO
    {

        public int? ServicioDispositivoSeguridadPrestadoId { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaHoraInicio { get; set; }
        public string? FechaHoraTermino { get; set; }
        public int? EfectivoParticipante { get; set; }
        public string? Lugar { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? ObservacionServicioDispositivo { get; set; }
        public int? ComisionPorMes { get; set; }
        public int? CargaId { get; set; }

        public string? DescZonaNaval { get; set; }
        public string? DescDependecia { get; set; }
        public string? DescDistrito { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}