using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combima1
{
        public partial class EvaluacionAlistEntrenamientoCombima1DTO
        {

            public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
            public int? UnidadNavalId { get; set; }
            public string? NivelEntrenamiento { get; set; }
            public int? CapacidadOperativaId { get; set; }
            public string? TipoCapacidadOperativo { get; set; }
            public int? EjercicioEntrenamientoAspectoId { get; set; }
            public string? DescEjercicioEntrenamiento { get; set; }
            public string? AspectoEvaluacion { get; set; }
            public string? Peso { get; set; }
            public int? CalificativoAsignadoEjercicioId { get; set; }
            public int? PuntajeObtenido { get; set; }
            public string? FechaPeriodoEvaluar { get; set; }
            public string? FechaRealizacionEjercicio { get; set; }
            public int? TiempoVigencia { get; set; }
            public string? FechaCaducidadEjercicio { get; set; }



            public string? DescUnidadNaval { get; set; }
            public string? DescCapacidadOperativa { get; set; }
            public string? Codigo { get; set; }
            public string? DescCalificativoAsignadoEjercicio { get; set; }

            [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
