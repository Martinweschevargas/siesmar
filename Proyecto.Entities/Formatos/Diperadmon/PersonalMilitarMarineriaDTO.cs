using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diperadmon
{
    public partial class PersonalMilitarMarineriaDTO
    {
        public int PersonalMilitarMarineriaId { get; set; }
        public string? DNIPMilitarMar { get; set; }
        public string? SexoPMilitarMar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? UbigeoNacimiento { get; set; }
        public string? FechaNacimientoPMilitarMar { get; set; }
        public string? UbigeoLabora { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaIngresoInstPMilitarMar { get; set; }
        public string? EstadoCivilPMilitarMar { get; set; }
        public string? CodigoGradoEstudioAlcanzado { get; set; }
        public string? GradoAñoEstudioPSPMilitarMar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? FechaAltaPMilitarMar { get; set; }
        public string? FechaIngresoDepPMilitarMar { get; set; }
        public string? FechaUltimoAscensoPMilitarMar { get; set; }
        public string? FechaUltimoReenganchePMilitarMar { get; set; }
        public int? PeriodoReenganchadoPMilitarMar { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public int? CargaId { get; set; }

        public string? DescGrado { get; set; }
        public string? DescDistritoNacimiento { get; set; }
        public string? DescDistritoLabora { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescGradoEstudioAlcanzado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
