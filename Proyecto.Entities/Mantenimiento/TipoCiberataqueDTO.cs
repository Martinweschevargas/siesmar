using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoCiberataqueDTO
    {
        public int TipoCiberataqueId { get; set; }
        public string? DescTipoCiberataque { get; set; }
        public string? CodigoTipoCiberataque { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
