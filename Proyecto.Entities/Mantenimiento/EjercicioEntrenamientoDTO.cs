using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EjercicioEntrenamientoDTO
    {
        public int EjercicioEntrenamientoId { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? CodigoEjercicioEntrenamiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
