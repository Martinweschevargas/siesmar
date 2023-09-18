using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AreaDiperadmonDTO
    {
        public int AreaDiperadmonId { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
