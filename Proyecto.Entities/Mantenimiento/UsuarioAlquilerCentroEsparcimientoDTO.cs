using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UsuarioAlquilerCentroEsparcimientoDTO
    {
        public int UsuarioAlquilerCentroEsparcimientoId { get; set; }
        public string? DescUsuarioAlquilerCentroEsparcimiento { get; set; }
        public string? CodigoUsuarioAlquilerCentroEsparcimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
