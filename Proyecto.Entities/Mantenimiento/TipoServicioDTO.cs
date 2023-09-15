using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoServicioDTO
    {
        public int TipoServicioId { get; set; }
        public string? DescTipoServicio { get; set; }
        public string? CodigoTipoServicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
