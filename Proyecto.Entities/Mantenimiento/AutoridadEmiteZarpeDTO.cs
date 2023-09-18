using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AutoridadEmiteZarpeDTO
    {
        public int AutoridadEmiteZarpeId { get; set; }
        public string? DescAutoridadEmiteZarpe { get; set; }
        public string? CodigoAutoridadEmiteZarpe { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
