using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresna
{
    public partial class PostulantesEscuelaNavalDTO
    {

        public int? PostulanteEscuelaNavalId { get; set; }
        public string? DNIPostulante { get; set; }
        public string? SexoPostulante { get; set; }
        public string? FechaNacimientoPostulante { get; set; }
        public decimal? TallaPostulante { get; set; }
        public decimal? PesoPostulante { get; set; }
        public string? UbigeoNacimiento { get; set; }
        public string? UbigeoDomicilio { get; set; }
        public string? TipoInstitucionEducativa { get; set; }
        public string? CodigoInstitucionEducativa { get; set; }
        public string? UbigeoInstitucion { get; set; }
        public string? PadresMilitar { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public string? ConcursoAdmision { get; set; }
        public string? CodigoModalidadIngresoEsna { get; set; }
        public string? TipoPreparacion { get; set; }
        public string? DeportistaCalificado { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? QVecesPostulacion { get; set; }
        public string? CodigoPublicidadEsna { get; set; }
        public string? SituacionIngreso { get; set; }

        public string? DescDistritoNacimiento { get; set; }
        public string? DescDistritoDomicilio { get; set; }
        public string? DescDistritoInstitucion { get; set; }
        public string? DescInstitucionEducativa { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        public string? DescModalidadIngresoEsna { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescPublicidadEsna { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
