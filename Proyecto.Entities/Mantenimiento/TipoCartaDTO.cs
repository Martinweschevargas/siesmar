using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoCartaDTO
    {
        public int TipoCartaId { get; set; }
        public string? DescTipoCarta { get; set; }
        public string? CodigoTipoCarta { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
