
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadNavalDTO
    {
        public int UnidadNavalId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? CascoNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
