
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GradoPersonalMilitarDTO
    {
        public int GradoPersonalMilitarId { get; set; }
        public string? DescGrado { get; set; }
        public string? Abreviatura { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public int GradoPersonalId { get; set; }
        public string? DescGradoPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
