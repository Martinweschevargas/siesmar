using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class DocenteInstitucioesEducativasDTO
    {

        public int? DocenteInstitucionEducativaId { get; set; }
        public string? DNIDocente { get; set; }
        public string? SexoDocente { get; set; }
        public string? JornadaLaboral { get; set; }
        public string? CodigoCondicionLaboralDocente { get; set; }
        public string? CodigoDocenteCategoria { get; set; }
        public string? CodigoGradoEstudioAlcanzado { get; set; }
        public string? CodigoInstitucionEducativa { get; set; } 


        public string? DescCondicionLaboralDocente { get; set; }
        public string? DescDocenteCategoria { get; set; }
        public string? DescGradoEstudioAlcanzado { get; set; }
        public string? DescInstitucionEducativa { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
