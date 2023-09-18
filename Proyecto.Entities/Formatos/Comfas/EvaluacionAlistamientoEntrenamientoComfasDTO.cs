using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class EvaluacionAlistamientoEntrenamientoComfasDTO
    {

        public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public int? CodigoEjercicioEntrenamiento { get; set; }
        public int? EjercicioEntrenamientoId { get; set; }
        public int? EjercicioEntrenamientoAspectoId { get; set; }
        public int? PesoEjercicioEntrenamienti { get; set; }
        public int? CalificativoAsignadoEjercicioId { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? DescEjercicioEntrenamientoAspecto { get; set; }
        public string? DescCalificativoAsignadoEjercicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
