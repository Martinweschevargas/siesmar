using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MedioInvestigacionDTO
    {
        public int MedioInvestigacionId { get; set; }
        public string? DescMedioInvestigacion { get; set; }
        public string? CodigoMedioInvestigacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
