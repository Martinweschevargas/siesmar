using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class EvaluacionAlistamientoEntrenamientoComestreDTO
    {

        public int? EvaluacionAlistamientoEntrenamientoComestreId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public string? TipoCapacidadOperativo { get; set; }
        public int? CodigoEjercicioEntrenamiento { get; set; }
        public int? EjercicioEntrenamientoId { get; set; }
        public int? EjercicioEntrenamientoAspectoId { get; set; }
        public int? PesoEjercicioEntrenamiento { get; set; }
        public int? CalificativoAsignadoEjercicioId { get; set; }
        public int? PuntajeObtenido { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }
        public string? FechaCaducidadEjercicio { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? DescEjercicioEntrenamientoAspecto { get; set; }
        public string? AspectoEvaluacion { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}