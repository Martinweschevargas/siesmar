using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoBajaDTO
    {
        public int TipoBajaId { get; set; }
        public string? DescTipoBaja { get; set; }
        public string? CodigoTipoBaja { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
