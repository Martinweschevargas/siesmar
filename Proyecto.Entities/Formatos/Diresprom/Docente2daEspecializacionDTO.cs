using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresprom
{
    public partial class Docente2daEspecializacionDTO
    {

        public int? Docente2daEspecializacionId { get; set; }
        public int? DNIPersonalDocente { get; set; }
        public string? TipoPersonalDocente { get; set; }
        public string? CodigoCondicionLaboralDocente { get; set; }
        public string? CodigoRegimenLaboral { get; set; }
        public string? DedicacionTiempoDocente { get; set; }
        public string? CodigoNivelEstudio { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public int? CargaId { get; set; }
        public string? DescCondicionLaboralDocente { get; set; }
        public string? DescRegimenLaboral { get; set; }
        public string? DescNivelEstudio { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
