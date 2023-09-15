using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CoeficientePonderadoAMUCCMMDTO
    {
        public int CoeficientePonderadoAMUCCMMId { get; set; }
        public string? Municion { get; set; }
        public int CoeficientePonderacion { get; set; }
        public int ExistenciaMunicion { get; set; }
        public int MunicionRequerida { get; set; }
        public int TotalPorcentaje { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
