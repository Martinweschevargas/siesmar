using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MaterialIncautadoDTO
    {
        public int MaterialIncautadoId { get; set; }
        public string? DescMaterialIncautado { get; set; }
        public string? CodigoMaterialIncautado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
