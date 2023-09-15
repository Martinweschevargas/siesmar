using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoManiobraDTO
    {
        public int TipoManiobraId { get; set; }
        public string? DescTipoManiobra { get; set; }
        public string? CodigoTipoManiobra { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
