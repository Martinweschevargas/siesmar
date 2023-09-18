using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClaseCombustibleDTO
    {
        public int ClaseCombustibleId { get; set; }
        public string? DescClaseCombustible { get; set; }
        public string? CodigoClaseCombustible { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
