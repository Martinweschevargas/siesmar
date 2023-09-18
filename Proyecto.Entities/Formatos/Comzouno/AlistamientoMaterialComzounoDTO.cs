using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzouno
{
    public partial class AlistamientoMaterialComzounoDTO
    {

        public int AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public decimal? PorcentajeOperatividad { get; set; }
        public decimal? PonderadoFuncional { get; set; }
        public decimal? NivelAlistamientoParcial { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public string? Ponderado1N { get; set; }
        public string? Subclasificacion2 { get; set; }
        public string? Ponderado2Nivel { get; set; }
        public string? Subclasificacion3 { get; set; }
        public string? Ponderado3Nivel { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
