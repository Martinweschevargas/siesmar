using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InspeccionConocimientoDTO
    {
        public int InspeccionConocimientoId { get; set; }
        public string? DescInspeccionConocimiento { get; set; }
        public string? CodigoInspeccionConocimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
