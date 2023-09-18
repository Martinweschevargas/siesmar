using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DescripcionMaterialDTO
    {
        public int DescripcionMaterialId { get; set; }
        public string? Clasificacion { get; set; }
        public string? CodigoDescripcionMaterial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
