using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoCombustibleComoperguardDTO
    {
        public int TipoCombustibleComoperguardId { get; set; }
        public string? DescTipoCombustibleComoperguard { get; set; }
        public string? CodigoTipoCombustibleComoperguard { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
