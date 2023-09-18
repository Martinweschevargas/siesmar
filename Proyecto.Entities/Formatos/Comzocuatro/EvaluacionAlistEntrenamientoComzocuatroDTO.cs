using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzocuatro
{
        public partial class EvaluacionAlistEntrenamientoComzocuatroDTO
    {

            public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
            public string? CodigoUnidadNaval { get; set; }
            public string? CodigoNivelEntrenamiento { get; set; }
            public string? CodigoCapacidadOperativa { get; set; }
            public string? TipoCapacidadOperativo { get; set; }
            public string? CodigoEjercicioEntrenamientoAspecto { get; set; }
            public string? DescEjercicioEntrenamiento { get; set; }
            public string? AspectoEvaluacion { get; set; }
            public string? Peso { get; set; }
            public string? CodigoCalificativoAsignadoEjercicio { get; set; }
            public int? PuntajeObtenido { get; set; }
            public string? FechaPeriodoEvaluar { get; set; }
            public string? FechaRealizacionEjercicio { get; set; }
            public int? TiempoVigencia { get; set; }
            public string? FechaCaducidadEjercicio { get; set; }



            public string? DescUnidadNaval { get; set; }
            public string? DescCapacidadOperativa { get; set; }
            public string? Codigo { get; set; }
            public string? DescCalificativoAsignadoEjercicio { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
