using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoArmamentoDTO
    {
        public int TipoArmamentoId { get; set; }
        public string? DescTipoArmamento { get; set; }
        public string? CodigoTipoArmamento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
