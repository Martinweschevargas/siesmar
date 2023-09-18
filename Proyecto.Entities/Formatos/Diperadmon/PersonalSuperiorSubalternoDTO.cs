using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diperadmon
{
    public partial class PersonalSuperiorSubalternoDTO
    {
        public int PersonalSuperiorSubalternoId { get; set; }
        public string? DNIPSupSub { get; set; }
        public string? CodigoProcedencia { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? Sexo { get; set; }
        public string? UbigeoNacimiento { get; set; }
        public string? FechaNacimientoPSupSub { get; set; }
        public string? UbigeoLabora { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaIngresoDepPSupSub { get; set; }
        public string? EstadoCivilPSupSub { get; set; }
        public string? CodigoGradoEstudioAlcanzado { get; set; }
        public string? CodigoSistemaPension { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? FechaIngresoInstitucion { get; set; }
        public string? FechaAltaPSupSub { get; set; }
        public string? FechaUltimoAscensoPSupSub { get; set; }

        public int? CargaId { get; set; }
        public string? DescProcedencia { get; set; }
        public string? DescGrado { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescGradoEstudioAlcanzado { get; set; }
        public string? DescSistemaPension { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescDistritoLabora { get; set; }
        public string? DescDistritoNacimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
