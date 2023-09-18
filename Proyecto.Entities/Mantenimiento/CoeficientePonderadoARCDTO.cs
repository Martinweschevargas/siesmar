using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CoeficientePonderadoARCDTO
    {
        public int CoeficientePonderadoARCId { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public int CLM { get; set; }
        public int FM { get; set; }
        public int CM { get; set; }
        public int FT { get; set; }
        public int AUX { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
