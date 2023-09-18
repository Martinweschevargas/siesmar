using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPrendaDTO
    {
        public int TipoPrendaId { get; set; }
        public string? DescTipoPrenda { get; set; }
        public string? CodigoTipoPrenda { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
