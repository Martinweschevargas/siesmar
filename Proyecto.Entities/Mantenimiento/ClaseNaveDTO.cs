using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClaseNaveDTO
    {
        public int ClaseNaveId { get; set; }
        public string? DescClaseNave { get; set; }
        public string? CodigoClaseNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
