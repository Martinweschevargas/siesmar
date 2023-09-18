using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionAltaDTO
    {
        public int CondicionAltaId { get; set; }
        public string? DescCondicionAlta { get; set; }
        public string? CodigoCondicionAlta { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
