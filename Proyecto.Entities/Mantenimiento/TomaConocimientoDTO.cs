using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TomaConocimientoDTO
    {
        public int TomaConocimientoId { get; set; }
        public string? DescTomaConocimiento { get; set; }
        public string? CodigoTomaConocimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
