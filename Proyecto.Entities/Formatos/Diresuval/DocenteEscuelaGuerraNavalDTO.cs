using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresuval
{
    public partial class DocenteEscuelaGuerraNavalDTO
    {

        public int? DocenteEscuelaGuerraNavalId { get; set; }
        public string? DNIDocenteEscuela { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoCondicionLaboralDocente { get; set; }
        public string? CodigoRegimenLaboral { get; set; }
        public string? DedicacionDocente { get; set; }
        public string? CodigoGradoEstudioAlcanzado { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }



        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescCondicionLaboralDocente { get; set; }
        public string? DescRegimenLaboral { get; set; }
        public string? DescGradoEstudioAlcanzado { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        public int? CargaId { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
