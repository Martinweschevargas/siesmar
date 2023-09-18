using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoInformacionEmitidaDTO
    {
        public int TipoInformacionEmitidaId { get; set; }
        public string? DescTipoInformacionEmitida { get; set; }
        public string? CodigoTipoInformacionEmitida { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
