using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PuntoDistribucionPanificacionDTO
    {
        public int PuntoDistribucionPanificacionId { get; set; }
        public string? DescPuntoDistribucionPanificacion { get; set; }
        public string? CodigoPuntoDistribucionPanificacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
