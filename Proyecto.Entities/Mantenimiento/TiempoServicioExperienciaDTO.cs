using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TiempoServicioExperienciaDTO
    {
        public int TiempoServicioExperienciaId { get; set; }
        public char? BAPAmazonas { get; set; }
        public char? BAPLoreto { get; set; }
        public char? BAPMaranon { get; set; }
        public char? BAPUcayali { get; set; }
        public char? BAPClavero { get; set; }
        public char? BAPCastillo { get; set; }
        public char? BAPMorona { get; set; }
        public char? BAPCorrientes { get; set; }
        public char? BAPPastaza { get; set; }
        public char? Personal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
