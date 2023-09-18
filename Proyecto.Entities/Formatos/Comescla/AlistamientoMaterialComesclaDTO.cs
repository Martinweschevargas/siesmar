using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescla
{
    public partial class AlistamientoMaterialComesclaDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public int? AlistamientoMaterialRequerido3NId { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public string? PorcentajeOperatividad { get; set; }


        public string? DescCapacidadOperativa { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public decimal? Ponderado1N { get; set; }
        public string? Subclasificacion2 { get; set; }
        public decimal? Ponderado2Nivel { get; set; }
        public string? Subclasificacion3 { get; set; }
        public decimal? Ponderado3Nivel { get; set; }





        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
