using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoMaterialRequeridoComescuamaDTO
    {
        public int AlistamientoMaterialRequeridoComescuamaId { get; set; }
        public string? CodigoAlistamientoMaterialRequeridoComescuama { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public string? Subclasificacion { get; set; }
        public string? Requerido { get; set; }
        public string? Operativo { get; set; }
        public string? PorcentajeOperatividad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
