using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SituacionOperatividadNaveDTO
    {
        public int SituacionOperatividadNaveId { get; set; }
        public string? Nave { get; set; }
        public string? NumeroCasco { get; set; }
        public string? TipoPlataforma { get; set; }
        public string? CodigoDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
