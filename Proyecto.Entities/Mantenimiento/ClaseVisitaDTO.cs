using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClaseVisitaDTO
    {
        public int ClaseVisitaId { get; set; }
        public string? DescClaseVisita { get; set; }
        public string? CodigoClaseVisita { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
