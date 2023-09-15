using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class EvaluacionAlistamientoEntrenamientoComfasubDTO
    {
        public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoNivelEntrenamiento { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? TipoCapacidadOperativa { get; set; }
        public string? CodigoEjercicioEntrenamientoComfasub { get; set; }
        public string? EjercicioEntrenamientoAspectos { get; set; }
        public string? PesoAspectosEjercicio { get; set; }
        public string? CodigoCalificativoAsignadoEjercicio { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }
        public int? HoraNavegacionUnidad { get; set; }
        public int? OperativoDespliegueRealizado { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescNivelEntrenamiento { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? Descripcion { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
