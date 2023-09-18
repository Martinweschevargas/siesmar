using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProductoResultadoObtenidoDTO
    {
        public int ProductoResultadoObtenidoId { get; set; }
        public string? DescProductoResultadoObtenido { get; set; }
        public string? CodigoProductoResultadoObtenido { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
