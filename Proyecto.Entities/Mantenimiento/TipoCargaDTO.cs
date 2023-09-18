using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoCargaDTO
    {
        public int TipoCargaId { get; set; }
        public string? DescTipoCarga { get; set; }
        public string? CodigoTipoCarga { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
