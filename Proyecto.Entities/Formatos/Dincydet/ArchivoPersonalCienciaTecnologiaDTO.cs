using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class ArchivoPersonalCienciaTecnologiaDTO
    {
        public int ArchivoPersonalCienciaTecnologiaId { get; set; }
        public string? DNIPersonalCT { get; set; }
        public int? AniosTrabajoPersonalCT { get; set; }
        public string? SexoPersonalCT { get; set; }
        public string? CodigoFormacionAcademica { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoTituloProfesionalObtenido { get; set; }
        public string? NaturalezaTrabajoPersonalCT { get; set; }
        public string? EspecializacionPersonaCT { get; set; }
        public string? CodigoAreaCT { get; set; }
        public string? DedicacionTiempoPersonalCT { get; set; }
        public string? ParticipacionProgramas { get; set; }
        public string? DescFormacionAcademica { get; set; }
        public string? DescGrado { get; set; }
        public string? DescTituloProfesionalObtenido { get; set; }
        public string? DescAreasCT { get; set; }
        public string? DescAreaCT { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
