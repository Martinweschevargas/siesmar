using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirnotemat
{
    public partial class ProcesoInternamientoDTO
    {
        public int ProcesoInternamientoId { get; set; }
        public string? NombreProceso { get; set; }
        public string? NroContratoProceso { get; set; }
        public string? CodigoTipoProcesoDirnotemat { get; set; }
        public string? NroProcesoInternamiento { get; set; }
        public string? NroguiaProceso { get; set; }
        public string? FechaIngresoProceso { get; set; }
        public string? TiempoEvaluacion { get; set; }
        public string? ResultadoEvaluacion { get; set; }
        public string? LaboratorioProcesoInternamiento { get; set; }
        public string? DescTipoProcesoDirnotemat { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
