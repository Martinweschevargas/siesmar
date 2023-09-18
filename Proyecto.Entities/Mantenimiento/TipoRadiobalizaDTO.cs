using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoRadiobalizaDTO
    {
        public int TipoRadiobalizaId { get; set; }
        public string? DescTipoRadiobaliza { get; set; }
        public string? CodigoTipoRadiobaliza { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
