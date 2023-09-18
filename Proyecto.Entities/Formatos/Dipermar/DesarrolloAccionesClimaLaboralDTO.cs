using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dipermar
{
    public partial class DesarrolloAccionesClimaLaboralDTO
    {

        public int? DesarrolloAccionClimaLaboralId { get; set; }
        public string? CodigoActClimaLaboralGeneral { get; set; }
        public string? CodigoActClimaLaboralEspecifica { get; set; }
        public string? TematicaActividad { get; set; }
        public string? LugarActividad { get; set; }
        public string? FechaInicioActividad { get; set; }
        public string? FechaTerminoActividad { get; set; }
        public int? NroHorasActividad { get; set; }
        public int? NumeroPersonalSuperior { get; set; }
        public string? CodigoDependencia { get; set; }
        public int? NroPersonalSubalterno { get; set; }
        public int? NroPersonalMarineria { get; set; }
        public int? NroPersonalCivil { get; set; }
        public string? DescActClimaLaboralGeneral { get; set; }
        public string? DescActClimaLaboralEspecifica { get; set; }
        public string? NombreDependencia { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
