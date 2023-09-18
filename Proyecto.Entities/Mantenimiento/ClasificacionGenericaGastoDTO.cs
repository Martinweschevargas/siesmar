using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionGenericaGastoDTO
    {
        public int ClasificacionGenericaGastoId { get; set; }
        public string? DescClasificacionGenericaGasto { get; set; }
        public string? ClasificacionGenericaGasto { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
