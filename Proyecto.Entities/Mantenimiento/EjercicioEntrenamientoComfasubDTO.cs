using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EjercicioEntrenamientoComfasubDTO
    {
        public int EjercicioEntrenamientoComfasubId { get; set; }
        public string? CodigoEjercicioEntrenamiento { get; set; }
        public string? CodigoCapacidadOperativa { get; set; }
        public string? DescEjercicioEntrenamiento { get; set; }
        public string? NivelEjercicio { get; set; }
        public int? VigenciaDiasClaseIslay { get; set; }
        public int? VigenciaDiasClaseAngamos { get; set; }

        public string? DescCapacidadOperativa { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
