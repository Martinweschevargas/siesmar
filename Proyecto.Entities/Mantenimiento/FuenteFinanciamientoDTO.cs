using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FuenteFinanciamientoDTO
    {
        public int FuenteFinanciamientoId { get; set; }
        public string? DescFuenteFinanciamiento { get; set; }
        public string? CodigoFuenteFinanciamiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
