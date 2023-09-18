using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroRINFODTO
    {

        public int? RegistroRINFOId { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaReporte { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? NombreInfractor { get; set; }
        public string? TipoInfraccion { get; set; }
        public string? MotivoIncumplimiento { get; set; }
        public string? AplicacionSancion { get; set; }
        public string? DisposicionEmitidaPrevencion { get; set; }
        public string? OtroInformacionAdicional { get; set; }


        public string? DescDependencia { get; set; }
        public string? DescGrado { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}