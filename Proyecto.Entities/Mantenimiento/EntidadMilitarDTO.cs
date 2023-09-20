using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EntidadMilitarDTO
    {
        public int EntidadMilitarId { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? AbrevEntidadMilitar { get; set; }
        public string? CodigoEntidadMilitar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
