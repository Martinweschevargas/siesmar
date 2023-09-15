using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class PoblacionEstudiantilMatriculadosDTO
    {

        public int? PoblacionEstudiantilMatriculadoId { get; set; }
        public string? DNIMatriculado { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? SexoMatriculado { get; set; }
        public string? CodigoInstitucionEducativa{ get; set; }
        public string? CodigoNivelEstudio { get; set; }
        public string? GradoEstudio { get; set; }
        public string? CodigoSeccionEstudio { get; set; }
        public string? EspecificacionEstudio { get; set; }
        public string? CodigoCategoriaPago { get; set; }
        public string? CodigoResultadoEjercicioEducativo { get; set; }
        public int? CargaId { get; set; }
        public string? DescInstitucionEducativa { get; set; }
        public string? DescNivelEstudio { get; set; }
        public string? DescSeccionEstudio { get; set; }
        public string? DescCategoriaPago { get; set; }
        public string? DescResultadoEjercicioEducativo { get; set; }
        public string? GradoEstudioS { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
