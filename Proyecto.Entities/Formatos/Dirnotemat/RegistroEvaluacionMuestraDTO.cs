using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirnotemat
{
    public partial class RegistroEvaluacionMuestraDTO
    {
        public int RegistroEvaluacionMuestraId { get; set; }
        public string? DescProcesoEvaluacion { get; set; }
        public string? NroProcesoEvaluacion { get; set; }
        public int? NroMuestrasEvaluacion { get; set; }
        public int? MuestrasCumpleEvaluacion { get; set; }
        public int? MuestaNoCumpleEvaluacion { get; set; }
        public string? FechaInicioEvaluacion { get; set; }
        public string? FechaTerminoEvaluacion { get; set; }
        public string? LaboratorioEvaluacion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
