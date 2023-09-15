using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class VisitaMuseoNavalDTO
    {
        public int VisitaMuseoNavalId { get; set; }
        public int? MuseoNavalId { get; set; }
        public string? PeriodoVisitaMuseoNaval { get; set; }
        public int? QNinos { get; set; }
        public int? QAdultos { get; set; }
        public int? QEstudianteEscolar { get; set; }
        public int? QEstudianteUniversitario { get; set; }
        public int? QDocente { get; set; }
        public int? QMilitar { get; set; }
        public int? QFamiliaNavalAdulto { get; set; }
        public int? QFamiliaNavalNino { get; set; }
        public int? QPersonaDiscapacitada { get; set; }
        public int? QAdultosCivilMayor65 { get; set; }
        public int? QExtranjera { get; set; }
        public int? QOtroExtranjero { get; set; }
        public int? QNochesLima { get; set; }
        public int? TotalQVisita { get; set; }
        public decimal? RacaudacionTotal { get; set; }
        public string? DescMuseoNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
