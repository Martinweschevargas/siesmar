using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AsuntoApelacionReconsideracionDTO
    {
        public int AsuntoApelacionReconsideracionId { get; set; }
        public string? DescAsuntoApelacionReconsideracion { get; set; }
        public string? CodigoAsuntoApelacionReconsideracion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
