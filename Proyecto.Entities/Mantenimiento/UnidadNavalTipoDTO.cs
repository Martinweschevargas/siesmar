using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadNavalTipoDTO
    {
        public int UnidadNavalTipoId { get; set; }
        public string? DescUnidadNavalTipo { get; set; }
        public string? CodigoUnidadNavalTipo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
