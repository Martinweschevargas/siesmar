using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UsuarioCentroEsparcimientoDTO
    {
        public int UsuarioCentroEsparcimientoId { get; set; }
        public string? DescUsuarioCentroEsparcimiento { get; set; }
        public string? CodigoUsuarioCentroEsparcimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
