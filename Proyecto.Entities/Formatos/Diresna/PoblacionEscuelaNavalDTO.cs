using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresna
{
    public partial class PoblacionEscuelaNavalDTO
    {

        public int PoblacionEscuelaNavalId { get; set; }
        public string? DNIEstudianteEsna { get; set; }
        public string? SexoEstudianteEsna { get; set; }
        public string? FechaNacimientoEstudiante { get; set; }
        public decimal? TallaEstudianteEsna { get; set; }
        public decimal? PesoEstudianteEsna { get; set; }
        public string? DistritoNacimientoEstudiante { get; set; }
        public string? DistritoDomicilioEstudiante { get; set; }
        public string? FechaIngresoEstudiante { get; set; }
        public string? BecadoEsna { get; set; }
        public string? DistritoProcedencia { get; set; }
        public string? CodigoAnioAcademicoEsna { get; set; }
        public string? SemestreAcademico { get; set; }
        public decimal? IRASEstudianteEsna { get; set; }
        public decimal? NotaCaracterMilitar { get; set; }
        public decimal? NotaFormacionFisica { get; set; }
        public decimal? NotaConductaEstudiante { get; set; }
        public decimal? IRGSEstudianteEsna { get; set; }
        public decimal? IRGASEstudianteEsna { get; set; }
        public int? OrdenMerito { get; set; }
        public string? CodigoResultadoTerminoSemestre { get; set; }
        public string? CodigoCausalBaja { get; set; }
        public string? CodigoTipoAdmisionIngreso { get; set; }


        public string? DescDistritoNacimiento { get; set; }
        public string? DescDistritoDomicilio { get; set; }
        public string? DescDistritoProcedencia { get; set; }
        public string? DescAnioAcademicoEsna { get; set; }
        public string? DescResultadoTerminoSemestre { get; set; }
        public string? DescCausalBaja { get; set; }
        public string? DescTipoAdmisionIngreso { get; set; }

        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
