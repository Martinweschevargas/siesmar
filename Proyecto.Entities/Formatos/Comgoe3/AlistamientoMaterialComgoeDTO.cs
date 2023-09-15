using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comgoe3
{
    public partial class AlistamientoMaterialComgoeDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public int? AlistamientoMaterialRequerido3NId { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public decimal? PorcentajeOperatividad { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public string? Ponderado1N { get; set; }
        public string? Subclasificacion2 { get; set; }
        public string? Ponderado2Nivel { get; set; }
        public string? Subclasificacion3 { get; set; }
        public string? Ponderado3Nivel { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
