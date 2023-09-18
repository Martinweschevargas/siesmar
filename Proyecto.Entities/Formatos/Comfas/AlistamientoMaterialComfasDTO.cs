using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class AlistamientoMaterialComfasDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public int? CapacidadIntrinseca1 { get; set; }
        public int? PonderacionCapacidad1 { get; set; }
        public int? Subclasificacion2 { get; set; }
        public int? PonderacionCapacidad2 { get; set; }
        public int? Subclasificacion3 { get; set; }
        public int? PonderacionCapacidad3 { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public decimal? NivelAlistamientoParcial { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
