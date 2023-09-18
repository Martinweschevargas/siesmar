using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comesguard
{
    public partial class IngresoDatoServicioAlimentacionDTO
    {
        public int? IngresoDatoServicioAlimentacionId { get; set; }
        public int? NumeroRacion { get; set; }
        public int? MesId { get; set; }
        public int? PeriodoDias { get; set; }
        public string? CodigoDependencia { get; set; }
        public int? CantidadPersupe { get; set; }
        public int? CantidadPersuba { get; set; }
        public int? CantidadPermar { get; set; }
        public int? TotalPersonalVacaciones { get; set; }
        public int? TotalPersonalDiaHabil { get; set; }
        public int? TotalPersonalDiaNoHabil { get; set; }
        public int? DiaHabil { get; set; }
        public int? DiaNoHabil { get; set; } 

        public string? DescMes { get; set; }
        public string? DescDependencia { get; set; }

        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
