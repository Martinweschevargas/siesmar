using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DptoMercanciaPeligrosaDTO
    {
        public int DptoMercanciaPeligrosaId { get; set; }
        public string? DescDptoMercanciaPeligrosa { get; set; }
        public string? CodigoDptoMercanciaPeligrosa { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
