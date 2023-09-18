using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class RegistroPerdidaRoboIdentificacionComfasDTO
    {

        public int? RegistroPerdidaRoboIdentificacionId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaInforme { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? CIPPersonal { get; set; }
        public string? FechaIncidente { get; set; }
        public string? Motivo { get; set; }
        public string? MensajeNavalReferencia { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescEspecialidadGenericaPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
