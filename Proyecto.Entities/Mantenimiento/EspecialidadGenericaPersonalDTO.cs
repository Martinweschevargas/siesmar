
using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecialidadGenericaPersonalDTO
    {
        public int EspecialidadGenericaPersonalId { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? Abreviatura { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public int GradoPersonalMilitarId { get; set; }
        public string? DescGrado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
