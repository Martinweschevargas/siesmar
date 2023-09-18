using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoMaterialDestruidoDTO
    {
        public int TipoMaterialDestruidoId { get; set; }
        public string? DescTipoMaterialDestruido { get; set; }
        public string? CodigoTipoMaterialDestruido { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
