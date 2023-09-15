using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class CuadroRegistroViajeDTO
    {

        public int? CuadroRegistroViajeId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaRegistro { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? CIPPersonal { get; set; }
        public int? UbigeoOrigen { get; set; }
        public int? UbigeoDestino { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public int? TiempoDuracion { get; set; }
        public string? MedioViaje { get; set; }
        public string? DocumentoAutorizacion { get; set; }
        public string? MotivoViaje { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescEspecialidadGenericaPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
