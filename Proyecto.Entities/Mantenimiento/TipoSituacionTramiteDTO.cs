using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoSituacionTramiteDTO
    {
        public int TipoSituacionTramiteId { get; set; }
        public string? DescTipoSituacionTramite { get; set; }
        public string? CodigoTipoSituacionTramite { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
