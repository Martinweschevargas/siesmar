using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CentroGastoDTO
    {
        public int CentroGastoId { get; set; }
        public string? DescCentroGasto { get; set; }
        public string? CodigoCentroGasto { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
