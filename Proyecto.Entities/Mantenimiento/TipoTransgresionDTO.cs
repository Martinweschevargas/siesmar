using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoTransgresionDTO
    {
        public int TipoTransgresionId { get; set; }
        public string? DescTipoTransgresion { get; set; }
        public string? CodigoTipoTransgresion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
