using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MaterialDeportivoDTO
    {
        public int MaterialDeportivoId { get; set; }
        public string? DescMaterialDeportivo { get; set; }
        public string? CodigoMaterialDeportivo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
