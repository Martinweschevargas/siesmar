using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PuntoDistribucionCombustibleDTO
    {
        public int PuntoDistribucionCombustibleId { get; set; }
        public string? DescPuntoDistribucionCombustible { get; set; }
        public string? CodigoPuntoDistribucionCombustible { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
