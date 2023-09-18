using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dipermar
{
    public partial class InvestigacionDisciplinariaDTO
    {
        public int InvestigacionDisciplinariaId { get; set; }
        public string? FechaInicioInvestigacion { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SexoPersonal { get; set; }
        public string? CodigoInfraccionDisciplinariaGenerica { get; set; }
        public string? CodigoInfraccionDisciplinariaEspecifica { get; set; }
        public string? NivelInfraccion { get; set; }
        public string? CodigoGradoPresidenteJunta { get; set; }
        public string? NombrePresidenteJunta { get; set; }
        public string? ConclusionFinal { get; set; }
        public string? ConclusionFinalDescripcion { get; set; }
        public string? CodigoSancionDisciplinariaNaval { get; set; }
        public string? DescGrado { get; set; }
        public string? DescGradoPresidenteJunta { get; set; }
        public string? DescInfraccionDisciplinariaGenerica { get; set; }
        public string? DescInfraccionDisciplinariaEspecifica { get; set; }
        public string? DescSancionDisciplinariaNaval { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
