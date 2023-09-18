using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SeveridadCiberataqueDTO
    {
        public int SeveridadCiberataqueId { get; set; }
        public string? DescSeveridadCiberataque { get; set; }
        public string? CodigoSeveridadCiberataque { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
