using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoObraServicioDTO
    {
        public int TipoObraServicioId { get; set; }
        public string? DescTipoObraServicio { get; set; }
        public string? CodigoTipoObraServicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
