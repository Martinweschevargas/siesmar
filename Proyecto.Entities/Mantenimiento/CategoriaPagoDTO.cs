using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CategoriaPagoDTO
    {
        public int CategoriaPagoId { get; set; }
        public string? DescCategoriaPago { get; set; }
        public string? CodigoCategoriaPago { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
