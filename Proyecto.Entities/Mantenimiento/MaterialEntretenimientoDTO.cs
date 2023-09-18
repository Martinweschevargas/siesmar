using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MaterialEntretenimientoDTO
    {
        public int MaterialEntretenimientoId { get; set; }
        public string? DescMaterialEntretenimiento { get; set; }
        public string? CodigoMaterialEntretenimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
