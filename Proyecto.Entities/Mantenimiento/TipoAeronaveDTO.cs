using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAeronaveDTO
    {
        public int TipoAeronaveId { get; set; }
        public string? DescTipoAeronave { get; set; }
        public string? CodigoTipoAeronave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
