using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diredumar
{
    public partial class CapacitacionPerfeccionamientoExtraMDTO
    {
        public int CapacitacionPerfeccionamientoExtraMId { get; set; }
        public string? CIPCapaPerf { get; set; }
        public string? DNICapaPerf { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoNivelEstudio { get; set; }
        public string? CodigoInstitucionEducativaSuperior { get; set; }
        public string? MencionCapacitacion { get; set; }
        public string? FinanciamientoCapacitacion { get; set; }
        public string? NumericoPais { get; set; }
        public int? CargaId { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescNivelEstudio { get; set; }
        public string? DescInstitucionEducativaSuperior { get; set; }
        public string? NombrePais { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
