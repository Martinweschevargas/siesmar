using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPuertoPeruDTO
    {
        public int TipoPuertoPeruId { get; set; }
        public string? DescTipoPuertoPeru { get; set; }
        public string? CodigoTipoPuertoPeru { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
