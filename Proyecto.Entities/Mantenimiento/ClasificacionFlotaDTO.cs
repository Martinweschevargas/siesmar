using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionFlotaDTO
    {
        public int ClasificacionFlotaId { get; set; }
        public string? DescClasificacionFlota { get; set; }
        public string? CodigoClasificacionFlota { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
