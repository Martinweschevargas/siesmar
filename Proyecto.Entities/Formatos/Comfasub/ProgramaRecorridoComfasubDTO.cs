using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class ProgramaRecorridoComfasubDTO
    {

        public int ProgramaRecorridoComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoMaterialRequerido2N { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public int? RecorridoDia { get; set; }
        public int? CargaId { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public string? Subclasificacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}