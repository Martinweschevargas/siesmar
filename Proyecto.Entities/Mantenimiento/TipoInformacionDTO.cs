using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoInformacionDTO
    {
        public int TipoInformacionId { get; set; }
        public string? DescTipoInformacion { get; set; }
        public string? CodigoTipoInformacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
