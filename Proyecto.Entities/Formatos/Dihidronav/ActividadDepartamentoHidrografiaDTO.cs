using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class ActividadDepartamentoHidrografiaDTO
    {

        public int? ActividadDepartamentoHidrografiaId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? TrabajoEfectuado { get; set; }
        public string? CodigoTrabajoHidrografico { get; set; }
        public string? CodigoZonaNautica { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CodigoProductoResultadoObtenido { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? ResponsableActividad { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SituacionTrabajoEfectuado { get; set; }


        public string? DescTrabajoHidrografico { get; set; }
        public string? DescZonaNautica { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescProductoResultadoObtenido { get; set; }
        public string? DescGrado { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}