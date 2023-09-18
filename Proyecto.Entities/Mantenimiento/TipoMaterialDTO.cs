using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoMaterialDTO
    {
        public int TipoMaterialId { get; set; }
        public string? DescTipoMaterial { get; set; }
        public string? CodigoTipoMaterial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
