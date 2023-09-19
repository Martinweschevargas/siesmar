using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuavinav
{
    public partial class AlistamientoMaterialComfuavinavDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public decimal? PorcentajeOperativo { get; set; }
        public int? CargaId { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? CapacidadIntrinseca1N { get; set; }
        public string? Ponderado1N { get; set; }
        public string? Subclasificacion2N { get; set; }
        public string? Ponderado2Nivel { get; set; }
        public string? Subclasificacion3N { get; set; }
        public string? Ponderado3Nivel { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
