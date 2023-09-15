using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPresupuestoDTO
    {
        public int TipoPresupuestoId { get; set; }
        public string? DescTipoPresupuesto { get; set; }
        public string? CodigoTipoPresupuesto { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
