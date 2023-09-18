using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadBelicaDTO
    {
        public int UnidadBelicaId { get; set; }
        public string? DescUnidadBelica { get; set; }
        public string? CodigoUnidadBelica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
