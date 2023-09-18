using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PersonaActividadDifucionDTO
    {
        public int PersonaActividadDifucionId { get; set; }
        public string? DescPersonaActividadDifucion { get; set; }
        public string? CodigoPersonaActividadDifucion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
