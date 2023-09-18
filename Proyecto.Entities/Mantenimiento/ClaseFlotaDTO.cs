using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClaseFlotaDTO
    {
        public int ClaseFlotaId { get; set; }
        public string? DescClaseFlota { get; set; }
        public string? CodigoClaseFlota { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
