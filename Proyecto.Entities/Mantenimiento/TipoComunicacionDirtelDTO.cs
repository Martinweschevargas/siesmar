using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoComunicacionDirtelDTO
    {
        public int TipoComunicacionDirtelId { get; set; }
        public string? DescTipoComunicacionDirtel { get; set; }
        public string? CodigoTipoComunicacionDirtel { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
