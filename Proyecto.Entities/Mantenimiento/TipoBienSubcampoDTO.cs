using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoBienSubcampoDTO
    {
        public int TipoBienSubcampoId { get; set; }
        public string? DescTipoBienSubcampo { get; set; }
        public string? CodigoTipoBienSubcampo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
