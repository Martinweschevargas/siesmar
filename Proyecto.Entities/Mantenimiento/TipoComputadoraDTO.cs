using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoComputadoraDTO
    {
        public int TipoComputadoraId { get; set; }
        public string? DescTipoComputadora { get; set; }
        public string? CodigoTipoComputadora { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
