using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class CuadroDemostrativoPersonalComfasDTO
    {

        public int? CuadroDemostrativoPersonalComfasId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? Fecha { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? CIPPersonal { get; set; }
        public string? Condicion { get; set; }
        public int? UbigeoOrigen { get; set; }
        public int? UbigeoDestino { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public int? DuracionDias { get; set; }
        public string? DocumentoReferencia { get; set; }
        public string? Motivo { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescEspecialidadGenericaPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
