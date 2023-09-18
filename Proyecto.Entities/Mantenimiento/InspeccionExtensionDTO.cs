using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InspeccionExtensionDTO
    {
        public int InspeccionExtensionId { get; set; }
        public string? DescInspeccionExtension { get; set; }
        public string? CodigoInspeccionExtension { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
