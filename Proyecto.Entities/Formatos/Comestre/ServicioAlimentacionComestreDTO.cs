using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class ServicioAlimentacionComestreDTO
    {

        public int? ServicioAlimentacionComestreId { get; set; }
        public int? NumeroRacion { get; set; }
        public int? MesId { get; set; }
        public int? PeriodoDias { get; set; }
        public int? DependenciaId { get; set; }
        public int? CantidadPersupe { get; set; }
        public int? CantidadPersuba { get; set; }
        public int? CantidadPermar { get; set; }
        public int? Vacacion { get; set; }
        public int? TotalPersonalDiaHabil { get; set; }
        public int? TotalPersonalDiaNoHabil { get; set; }
        public int? DiaHabil { get; set; }
        public int? DiaNoHabil { get; set; }


        public string? DescMes { get; set; }
        public string? DescDependencia{ get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}