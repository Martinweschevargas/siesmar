using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClaseInversionDTO
    {
        public int ClaseInversionId { get; set; }
        public string? DescClaseInversion { get; set; }
        public string? CodigoClaseInversion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
