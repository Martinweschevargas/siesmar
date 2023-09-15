using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoProcesoDTO
    {
        public int TipoProcesoId { get; set; }
        public string? DescTipoProceso { get; set; }
        public string? CodigoTipoProceso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
