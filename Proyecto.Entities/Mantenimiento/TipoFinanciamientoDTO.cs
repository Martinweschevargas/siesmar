using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoFinanciamientoDTO
    {
        public int TipoFinanciamientoId { get; set; }
        public string? DescTipoFinanciamiento { get; set; }
        public string? CodigoTipoFinanciamiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
