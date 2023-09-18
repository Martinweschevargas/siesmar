using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescla
{
    public partial class EvaluacionAlistamientoEntrenamientoComesclaDTO
    {

        public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? NivelEntrenamientoId { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public string? TipoCapacidadOperativa { get; set; }
        public int? CodigoEjercicioEntrenamiento { get; set; }
        public int? EjercicioEntrenamiento { get; set; }
        public int? EjercicioEntrenamientoAspectos { get; set; }
        public int? PesoEjercicioEntrenamiento { get; set; }
        public int? CalificativoAsignadoEjercicioId { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescNivelEntrenamiento { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescCalificativoAsignadoEjercicio { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
