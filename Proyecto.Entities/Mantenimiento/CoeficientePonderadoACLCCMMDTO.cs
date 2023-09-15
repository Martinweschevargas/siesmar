using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CoeficientePonderadoACLCCMMDTO
    {
        public int CoeficientePonderadoACLCCMMId { get; set; }
        public string? CombustibleLubricante { get; set; }
        public int CoeficientePonderacion { get; set; }
        public int CLExistente { get; set; }
        public int CLRequerido { get; set; }
        public int Total { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
