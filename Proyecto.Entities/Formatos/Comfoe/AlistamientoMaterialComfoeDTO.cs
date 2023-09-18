using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfoe
{
    public partial class AlistamientoMaterialComfoeDTO
    {

        public int AlistamientoMaterialId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public int? Requerido { get; set; }
        public int? Operativo { get; set; }
        public int? PorcentajeOperatividad { get; set; }
        public int? PonderadoFuncional { get; set; }
        public int? NivelAlistamientoParcial { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }

        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
