using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PersonalCivilMDTO
    {
        public int PersonalCivilId { get; set; }
        public string? DescPersonalCivil { get; set; }
        public string? CodigoPersonalCivil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
