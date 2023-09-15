using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirciten
{
    public partial class InformacionDocenteDTO
    {
        public int InformacionDocenteId { get; set; }
        public string? DNIDocenteDirciten { get; set; }
        public string? TipoDocenteDirciten { get; set; }
        public string? CodigoCondicionLaboralDocente { get; set; }
        public string? CodigoRegimenLaboral { get; set; }
        public string? DedicacionDocente { get; set; }
        public string? CodigoNivelEstudio { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }


        public string? DescCondicionLaboralDocente { get; set; }
        public string? DescRegimenLaboral { get; set; }
        public string? DescNivelEstudio { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
