using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoComisionCaninaDTO
    {
        public int TipoComisionCaninaId { get; set; }
        public string? DescTipoComisionCanina { get; set; }
        public string? CodigoTipoComisionCanina { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
