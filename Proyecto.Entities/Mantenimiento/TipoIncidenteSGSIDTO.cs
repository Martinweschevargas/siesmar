using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoIncidenteSGSIDTO
    {
        public int TipoIncidenteSGSIId { get; set; }
        public string? DescTipoIncidenteSGSI { get; set; }
        public string? CodigoTipoIncidenteSGSI { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
