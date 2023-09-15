using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PersonalCivilLaboralDTO
    {
        public int PersonalCivilLaboralId { get; set; }
        public string? DescPersonalCivilLaboral { get; set; }
        public string? CodigoPersonalCivilLaboral { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
