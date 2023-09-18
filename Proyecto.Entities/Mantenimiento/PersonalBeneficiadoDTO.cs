using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PersonalBeneficiadoDTO
    {
        public int PersonalBeneficiadoId { get; set; }
        public string? DescPersonalBeneficiado { get; set; }
  	public string? CodigoPersonalBeneficiado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
