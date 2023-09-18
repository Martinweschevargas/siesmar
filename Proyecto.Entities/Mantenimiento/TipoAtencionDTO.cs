using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAtencionDTO
    {
        public int TipoAtencionId { get; set; }
        public string? DescTipoAtencion { get; set; }
        public string? CodigoTipoAtencion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
