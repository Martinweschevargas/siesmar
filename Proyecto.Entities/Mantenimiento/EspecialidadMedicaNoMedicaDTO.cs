using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecialidadMedicaNoMedicaDTO
    {
        public int EspecialidadMedicaNoMedicaId { get; set; }
        public string? DescEspecialidadMedicaNoMedica { get; set; }
        public string? CodigoUPS { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
