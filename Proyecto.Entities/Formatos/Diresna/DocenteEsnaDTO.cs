using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresna
{
    public partial class DocenteEsnaDTO
    {

        public int? DocenteEsnaId { get; set; }
        public string? DNIDocenteEsna { get; set; }
        public string? TipoDocente { get; set; }
        public string? CodigoCondicionLaboralDocente { get; set; }
        public string? CodigoRegimenLaboral { get; set; }
        public string? DedicacionDocente { get; set; }
        public string? CodigoNivelEstudio { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public int? ExperienciaDocente { get; set; }
        public int? ExperienciaDocenteMarina { get; set; }


        public string? DescCondicionLaboralDocente { get; set; }
        public string? DescRegimenLaboral { get; set; }
        public string? DescNivelEstudio { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
