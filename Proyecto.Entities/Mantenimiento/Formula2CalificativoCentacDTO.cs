using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class Formula2CalificativoCentacDTO
    {
        public int Formula2CalificativoCentacId { get; set; }
        public string? DescFormula2CalificativoCentac { get; set; }
        public string? CodigoFormula2CalificativoCentac { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
