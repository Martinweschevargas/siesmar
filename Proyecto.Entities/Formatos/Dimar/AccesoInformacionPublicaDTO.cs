using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class AccesoInformacionPublicaDTO
    {

        public int? AccesoInformacionPublicaId { get; set; }
        public string? FechaRecepcion { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? FechaDocumento { get; set; }
        public string? Administrado { get; set; }
        public string? Asunto { get; set; }
        public string? DocumentoRespuesta { get; set; }
        public string? FechaUsuario { get; set; }
        public decimal? MontoRecaudado { get; set; }
        public int? TiempoRespuestaDias { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
