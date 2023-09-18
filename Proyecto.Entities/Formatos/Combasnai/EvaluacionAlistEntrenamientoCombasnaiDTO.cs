using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combasnai
{
    public partial class EvaluacionAlistEntrenamientoCombasnaiDTO
    {

        public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public string? TipoCapacidadOperativa { get; set; }
        public int? EjercicioEntrenamientoAspectoId { get; set; }
        public int? CodigoEjercicioEntrenamiento { get; set; }
        public int? EjercicioEntrenamiento { get; set; }
        public string? EjercicioEntrenamientoAspectos { get; set; }
        public int? PesoEjercicioEntrenamiento { get; set; }
        public int? CalificativoAsignadoEjercicioId { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescCalificativoAsignadoEjercicio { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
