using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combima1
{
    public partial class AlistamientoMaterialCombima1DTO
    {

        public int AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public int? Existencia { get; set; }
        public decimal? PorcentajeOperatividad { get; set; }
        public decimal? PonderadoFuncional { get; set; }
        public decimal? NivelAlistamientoParcial { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public int? CargaId { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
