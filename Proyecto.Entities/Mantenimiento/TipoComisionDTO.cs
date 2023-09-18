using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoComisionDTO
    {
        public int TipoComisionId { get; set; }
        public string? DescTipoComision { get; set; }
        public string? CodigoTipoComision { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
