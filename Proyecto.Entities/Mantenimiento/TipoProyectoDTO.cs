using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoProyectoDTO
    {
        public int TipoProyectoId { get; set; }
        public string? DescTipoProyecto { get; set; }
        public string? CodigoTipoProyecto { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
