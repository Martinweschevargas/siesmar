using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ResultadoApelacionReconsideracionDTO
    {
        public int ResultadoApelacionReconsideracionId { get; set; }
        public string? DescResultadoApelacionReconsideracion { get; set; }
        public string? CodigoResultadoApelacionReconsideracion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
