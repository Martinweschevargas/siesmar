using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EjercicioEntrenamientoComfasDTO
    {
        public int EjercicioEntrenamientoComfasId { get; set; }
        public int CapacidadOperativaId { get; set; }
        public string? DescCapacidadOperativa { get; set; }
        public string? DescEjercicioEntrenamientoComfas { get; set; }
        public string? CodigoEjercicioEntrenamientoComfas { get; set; }
        public string? NivelEjercicio { get; set; }
        public int FFMM { get; set; }
        public int CMM { get; set; }
        public int DDTT { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
