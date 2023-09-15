using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EjercicioEntrenamientoAspectoDTO
    {
        public int EjercicioEntrenamientoAspectoId { get; set; }
        public string? AspectoEvaluacion { get; set; }
        public string? Peso { get; set; }
        public string? CodigoEjercicioEntrenamiento { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? CodigoEjercicioEntrenamientoAspecto { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
