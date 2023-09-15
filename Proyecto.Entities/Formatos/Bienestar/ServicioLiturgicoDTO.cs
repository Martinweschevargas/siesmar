using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class ServicioLiturgicoDTO
    {

        public int? ServicioLiturgicoId { get; set; }
        public string? FechaServicioLiturgico { get; set; }
        public string? DNISolicitante { get; set; }
        public string? CodigoPersonalSolicitante { get; set; }
        public string? CodigoCondicionSolicitante { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoPersonalBeneficiado { get; set; }
        public string? CodigoCategoriaPago { get; set; }
        public string? CodigoServicioReligioso { get; set; }


        public string? DescPersonalSolicitante { get; set; }
        public string? DescCondicionSolicitante { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescPersonalBeneficiado { get; set; }
        public string? DescCategoriaPago { get; set; }
        public string? DescServicioReligioso { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
