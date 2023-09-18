using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FaseInversionDTO
    {
        public int FaseInversionId { get; set; }
        public string? DescFaseInversion { get; set; }
        public string? CodigoFaseInversion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
