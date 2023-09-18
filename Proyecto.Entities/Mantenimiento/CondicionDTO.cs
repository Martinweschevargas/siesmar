using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionDTO
    {
        public int CondicionId { get; set; }
        public string? DescCondicion { get; set; }
        public string? CodigoCondicion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
