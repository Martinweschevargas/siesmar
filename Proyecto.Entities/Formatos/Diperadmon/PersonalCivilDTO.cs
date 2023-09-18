using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diperadmon
{
    public partial class PersonalCivilDTO
    {
        public int PersonalCivilId { get; set; }
        public string? TipoDocumentoPCivil { get; set; }
        public string? DNIPCivil { get; set; }
        public string? SexoPCivil { get; set; }
        public string? CodigoCondicionLaboralCivil { get; set; }
        public string? CodigoGrupoOcupacionalCivil { get; set; }
        public string? NivelCargoPCivil { get; set; }
        public string? CodigoGrupoRemunerativo { get; set; }
        public string? CodigoGradoRemunerativo { get; set; }
        public string? CodigoRegimenLaboral { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public string? CodigoSistemaPension { get; set; }
        public string? FechaIngresoInstPCivil { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? DistritoLaboraPCivil { get; set; }
        public string? FechaIngresoPCivil { get; set; }
        public string? FechaNacimientoPCivil { get; set; }
        public string? DistritoNacimientoPCivil { get; set; }
        public string? EstadoCivilPCivil { get; set; }
        public string? CodigoGradoEstudioAlcanzado { get; set; }
        public string? GradoAñoEstudioPSPCivil { get; set; }
        public int? AnioServicioPCivil { get; set; }

        public string? DescCondicionLaboralPCivil { get; set; }
        public string? DescGrupoOcupacionalPCivil { get; set; }
        public string? DescGrupoRemunerativo { get; set; }
        public string? DescGradoRemunerativo { get; set; }
        public string? DescRegimenLaboral { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        public string? DescSistemaPension { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDistritoLaboraPCivil { get; set; }
        public string? DescDistritoNacimientoPCivil { get; set; }
        public string? DescGradoEstudioAlcanzado { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
