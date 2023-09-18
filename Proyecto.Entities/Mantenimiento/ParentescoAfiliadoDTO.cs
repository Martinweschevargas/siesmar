using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ParentescoAfiliadoDTO
    {
        public string? CodigoParentescoAfiliado { get; set; }
        public string? DescParentescoAfiliado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
