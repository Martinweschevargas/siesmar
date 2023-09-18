using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class ActividadDepartamentoOceanografiaDTO
    {

        public int? ActividadDepartamentoOceanografiaId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? CodigoTrabajoOceanografico   { get; set; }
        public string? DescripcionTrabajoEfectuado { get; set; }
        public string? CodigoZonaNautica { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? SituacionTrabajoEfectuado { get; set; }
        public string? DescTrabajoOceanografico { get; set; }
        public string? DescZonaNautica { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}