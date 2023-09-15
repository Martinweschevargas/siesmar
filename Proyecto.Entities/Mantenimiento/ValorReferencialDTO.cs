using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ValorReferencialDTO
    {
        public int ValorReferencialId { get; set; }
        public string? DescValorReferencial { get; set; }
        public string? CodigoValorReferencial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
