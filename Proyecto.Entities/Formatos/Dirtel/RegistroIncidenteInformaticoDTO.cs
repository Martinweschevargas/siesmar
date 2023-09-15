using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroIncidenteInformaticoDTO
    {

        public int? RegistroIncidenteInformaticoId { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaHoraIncidente { get; set; }
        public string? NombreQuienReporta { get; set; }
        public string? DescripcionIncidente { get; set; }
        public string? CodigoTipoIncidenteSGS { get; set; }
        public string? NivelPrioridad { get; set; }
        public string? EstrategiaErradicacion { get; set; }


        public string? DescDependencia { get; set; }
        public string? DescTipoIncidenteSGSI { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}