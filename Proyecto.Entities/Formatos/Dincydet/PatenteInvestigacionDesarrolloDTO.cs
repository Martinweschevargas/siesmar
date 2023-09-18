using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class PatenteInvestigacionDesarrolloDTO
    {
        public int PatenteInvestigacionDesarrolloId { get; set; }
        public string? DenominacionPatenteInvestigacion { get; set; }
        public string? EstadoPatenteInvestigacion { get; set; }
        public string? CodigoAreaCT { get; set; }
        public string? DescAreaCT { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
