using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EntidadConvocanteDTO
    {
        public int EntidadConvocanteId { get; set; }
        public string? DescEntidadConvocante { get; set; }
        public string? CodigoEntidadConvocante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
