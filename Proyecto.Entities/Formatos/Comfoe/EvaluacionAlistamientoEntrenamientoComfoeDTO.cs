using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfoe
{
    public partial class EvaluacionAlistamientoEntrenamientoComfoeDTO
    {
        public int EvaluacionAlistamientoEntrenamientoId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? CodigoEjercicioEntrenamientoComfoe { get; set; }
        public int? PuntajeObtenidoEjercicio { get; set; }
        public string? FechaPeriodoEvaluar { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? Nivel { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescTipoCompetenciaTecnica { get; set; }
        public string? DescripcionEjercicioEntrenamiento { get; set; }
        public string? VigenciaDia { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
