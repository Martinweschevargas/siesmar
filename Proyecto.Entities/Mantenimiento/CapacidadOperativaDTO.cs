using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CapacidadOperativaDTO
    {
        public int CapacidadOperativaId { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public int CodigoCapacidadOperativa { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
