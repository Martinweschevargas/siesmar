using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPrestamoConvenioDTO
    {
        public int TipoPrestamoConvenioId { get; set; }
        public string? DescTipoPrestamoConvenio { get; set; }
        public string? CodigoTipoPrestamoConvenio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
