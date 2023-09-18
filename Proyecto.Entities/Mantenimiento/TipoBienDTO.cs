using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoBienDTO
    {
        public int TipoBienId { get; set; }
        public string? DescTipoBien { get; set; }
        public string? CodigoTipoBien { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
