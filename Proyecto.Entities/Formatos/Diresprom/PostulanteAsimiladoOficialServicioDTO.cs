using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresprom
{
    public partial class PostulanteAsimiladoOficialServicioDTO
    {

        public int? PostulanteAsimiladoOficialServicioId { get; set; }
        public int? DNIPostulanteAsimilado { get; set; }
        public string? SexoPostulanteAsimilado { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? DistritoNacimiento { get; set; }
        public string? CodigoInstitucionEducativaSuperior { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public string? CodigoEspecialidadPostulacion { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? SituacionIngreso { get; set; }

        public string? DescInstitucionEducativaSuperior { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        public string? DescEspecialidadPostulacionI { get; set; }
        public string? DescZonaNaval { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
