using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class EstudioInvestigacionesHistoricasNavalesDTO
    {
        public int EstudioInvestigacionHistNavalId { get; set; }
        public string? NombreTemaEstudioInvestigacion { get; set; }
        public int TipoEstudioInvestigacionId { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? Responsable { get; set; }
        public string? Solicitante { get; set; }
        public string? DescTipoEstudioInvestigacion { get; set; }
        public int CodigoCargo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
