using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class AlistamientoMaterialComfasubDTO
    {

        public int? AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? FechaAlistamiento { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public decimal? PorcentajeOperatividad { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
