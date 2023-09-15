using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoServicioPublicoDTO
    {
        public int TipoServicioPublicoId { get; set; }
        public string? DescTipoServicioPublico { get; set; }
        public string? CodigoTipoServicioPublico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
