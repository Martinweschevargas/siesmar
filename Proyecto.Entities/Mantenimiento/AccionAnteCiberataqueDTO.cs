using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AccionAnteCiberataqueDTO
    {
        public int AccionAnteCiberataqueId { get; set; }
        public string? DescAccionAnteCiberataque { get; set; }
        public string? CodigoAccionAnteCiberataque { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
