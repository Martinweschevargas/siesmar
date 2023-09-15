using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DestinoPacienteDTO
    {
        public int DestinoPacienteId { get; set; }
        public string? DescDestinoPaciente { get; set; }
        public string? CodigoDestinoPaciente { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
