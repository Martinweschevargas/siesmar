using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CausalLiquidacionDTO
    {
        public int CausalLiquidacionId { get; set; }
        public string? DescCausalLiquidacion { get; set; }
        public string? CodigoCausalLiquidacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
