using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class ProgramaDiqueoComfasubDTO
    {

        public int ProgramaDiqueoComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoMaterialRequerido2N { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaSalida { get; set; }
        public int? PermanenciaDia { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public string? Subclasificacion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}