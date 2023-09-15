using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class OcupacionPersonalCivilDTO
    {
        public int OcupacionPersonalCivilId { get; set; }
        public string? DescOcupacionPersonalCivil { get; set; }
        public string? CodigoOcupacionPersonalCivil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
