using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AreaCTDTO
    {
        public int AreaCTId { get; set; }
        public string? DescAreaCT { get; set; }
        public string? CodigoAreaCT { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
