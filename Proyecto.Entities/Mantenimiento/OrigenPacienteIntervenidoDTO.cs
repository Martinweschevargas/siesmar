using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class OrigenPacienteIntervenidoDTO
    {
        public int OrigenPacienteIntervenidoId { get; set; }
        public string? DescOrigenPacienteIntervenido { get; set; }
        public string? CodigoOrigenPacienteIntervenido { get; set; }
        public string? AbrevOrigenPacienteIntervenido { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
