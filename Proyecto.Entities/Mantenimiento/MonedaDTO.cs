using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MonedaDTO
    {
        public int MonedaId { get; set; }
        public string? DescMoneda { get; set; }
        public string? CodigoMoneda { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
