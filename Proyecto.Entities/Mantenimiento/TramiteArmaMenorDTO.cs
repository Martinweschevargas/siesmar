using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TramiteArmaMenorDTO
    {
        public int TramiteArmaMenorId { get; set; }
        public string? DescTramiteArmaMenor { get; set; }

        public string? CodigoTramiteArmaMenor { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
