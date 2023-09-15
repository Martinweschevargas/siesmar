using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MaterialArmamentoDTO
    {
        public int MaterialArmamentoId { get; set; }
        public string? DescMaterialArmamento { get; set; }
        public string? CalibreMaterialArmamento { get; set; }
        public string? CodigoMaterialArmamento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
