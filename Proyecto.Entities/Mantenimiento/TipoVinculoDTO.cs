using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoVinculoDTO
    {
        public int TipoVinculoId { get; set; }
        public string? DescTipoVinculo { get; set; }
        public string? CodigoTipoVinculo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
