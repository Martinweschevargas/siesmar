using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DptoMaterialAcuaticoDTO
    {
        public int DptoMaterialAcuaticoId { get; set; }
        public string? DescDptoMaterialAcuatico { get; set; }
        public string? CodigoDptoMaterialAcuatico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
