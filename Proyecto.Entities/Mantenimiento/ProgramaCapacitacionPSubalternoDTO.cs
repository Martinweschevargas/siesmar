using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProgramaCapacitacionPSubalternoDTO
    {
        public int ProgramaCapacitacionPSubalternoId { get; set; }
        public string? DescProgramaCapacitacionPSubalterno { get; set; }
        public string? CodigoProgramaCapacitacionPSubalterno { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
