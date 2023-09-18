using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoDocumentoDTO
    {
        public int TipoDocumentoId { get; set; }
        public string? DescTipoDocumento { get; set; }
        public string? CodigoTipoDocumento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
