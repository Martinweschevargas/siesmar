using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModalidadVentaDTO
    {
        public int ModalidadVentaId { get; set; }
        public string? DescModalidadVenta { get; set; }
        public string? CodigoModalidadVenta { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
