using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class NivelAlistamientoDTO
    {
        public int NivelAlistamientoId { get; set; }
        public string? DescNivelAlistamiento { get; set; }
        public string? Calificativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
