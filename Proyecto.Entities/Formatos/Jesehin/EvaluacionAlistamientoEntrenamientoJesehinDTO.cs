using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Jesehin
{
    public partial class EvaluacionAlistamientoEntrenamientoJesehinDTO
    {
        public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public string? TipoCapacidadOperativa { get; set; }
        public int? EjercicioEntrenamientoAspectoId { get; set; }
        public int? CalificativoAsignadoEjercicioId { get; set; }
        public int? PuntajeObtenidoEjercicio { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }
        public string? FechaCaducidadEjercicio { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? CodigoEjercicioEntrenamiento { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? AspectoEvaluacion { get; set; }
        public string? Peso { get; set; }
        public string? Descripcion { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
