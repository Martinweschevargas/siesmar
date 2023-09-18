using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MaterialRecreativoDTO
    {
        public int MaterialRecreativoId { get; set; }
        public string? DescMaterialRecreativo { get; set; }
        public string? CodigoMaterialRecreativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
