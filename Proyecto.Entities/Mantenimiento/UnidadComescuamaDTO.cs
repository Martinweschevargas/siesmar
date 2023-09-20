using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public partial class UnidadComescuamaDTO
    {
        public int? UnidadComescuamaId { get; set; }
        public string? DescUnidadComescuama { get; set; }
        public string? CodigoUnidadComescuama { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}