using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuavinav
{
    public partial class EvaluacionAlistamientoEntrenamientoComfuavinavDTO
    {
        public int? EvaluacionAlistamientoEntrenamientoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public int? CapacidadOperativaId { get; set; }
        public int? TipoCompetenciaTecnicaId { get; set; }
        public int? EjercicioEntrenamientoId { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public int? TiempoVigencia { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescTipoCompetenciaTecnica { get; set; }
        public string? CodigoEjercicioEntrenamiento { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
