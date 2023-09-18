using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FormaContactoAfiliadoDTO
    {
        public int FormaContactoAfiliadoId { get; set; }
        public string? DescFormaContactoAfiliado { get; set; }
        public string? CodigoFormaContactoAfiliado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
