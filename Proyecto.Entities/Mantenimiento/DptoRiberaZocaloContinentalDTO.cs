using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DptoRiberaZocaloContinentalDTO
    {
        public int DptoRiberaZocaloContId { get; set; }
        public string? CodigoDptoRiberaZocaloCont { get; set; }
        public string? DescDptoRiberaZocaloCont { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
