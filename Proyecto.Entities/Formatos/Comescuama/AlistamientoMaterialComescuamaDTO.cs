using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class AlistamientoMaterialComescuamaDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadComescuama { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public string? CodigoAlistamientoMaterialRequeridoComescuama { get; set; }
        public decimal? PonderadoFuncional { get; set; }
        public decimal? NivelAlistamientoParcial { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadComescuama { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public string? Ponderado1N { get; set; }
        public string? Subclasificacion2N { get; set; }
        public string? Ponderado2Nivel { get; set; }
        public string? Subclasificacion3N { get; set; }
        public string? Ponderado3Nivel { get; set; }
        public string? Requerido { get; set; }
        public string? Operativo { get; set; }
        public string? PorcentajeOperatividad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
