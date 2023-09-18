using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AreaSatisfaceDirtelDTO
    {
        public int AreaSatisfaceDirtelId { get; set; }
        public string? DescAreaSatisfaceDirtel { get; set; }
        public string? CodigoAreaSatisfaceDirtel { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
