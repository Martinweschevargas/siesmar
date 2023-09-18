using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diredumar
{
    public partial class CapacitacionPerfeccionamientoMilitarDTO
    {
        public int CapacitacionPerfeccionamientoMilitarId { get; set; }
        public string? CIPCapPerf { get; set; }
        public string? DNICapPerf { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? NumericoPais { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoCodigoEscuela { get; set; }
        public string? MensionCurso { get; set; }
        public int? HorasCurso { get; set; }
        public int? CargaId { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? NombrePais { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? DescCodigoEscuela { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}