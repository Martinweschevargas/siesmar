using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoApoyoSocialDTO
    {
        public int TipoApoyoSocialId { get; set; }
        public string? DescTipoApoyoSocial { get; set; }
        public string? CodigoTipoApoyoSocial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
