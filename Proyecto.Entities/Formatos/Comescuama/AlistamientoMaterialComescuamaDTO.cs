using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class AlistamientoMaterialComescuamaDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public string? CodigoAlistamientoMaterialRequeridoComescuama { get; set; }
        public decimal? PonderadoFuncional { get; set; }
        public decimal? NivelAlistamientoParcial { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
