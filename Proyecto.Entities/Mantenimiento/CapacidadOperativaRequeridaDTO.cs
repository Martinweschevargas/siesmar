using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CapacidadOperativaRequeridaDTO
    {
        public int CapacidadOperativaRequeridaId { get; set; }
        public string? DescCapacidadOperativaRequerida { get; set; }
        public string? CodigoCapacidadOperativaRequerida { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
