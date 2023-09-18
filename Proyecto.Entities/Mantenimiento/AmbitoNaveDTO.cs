using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AmbitoNaveDTO
    {
        public int AmbitoNaveId { get; set; }
        public string? DescAmbitoNave { get; set; }
        public string? CodigoAmbitoNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
