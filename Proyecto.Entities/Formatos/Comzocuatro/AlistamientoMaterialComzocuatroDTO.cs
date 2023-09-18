using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzocuatro
{
    public partial class AlistamientoMaterialComzocuatroDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public int? PorcentajeOperatividad { get; set; }
        public decimal? PorcentajeFuncional { get; set; }
        public decimal? NivelAlistamientoParcial { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public decimal? Ponderado1N { get; set; }
        public string? Subclasificacion2 { get; set; }
        public decimal? Ponderado2Nivel { get; set; }
        public string? Subclasificacion3 { get; set; }
        public decimal? Ponderado3Nivel { get; set; }

        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
