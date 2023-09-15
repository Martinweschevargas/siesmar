using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DenominacionBaseDatoDTO
    {
        public int DenominacionBaseDatoId { get; set; }
        public string? DescDenominacionBaseDato { get; set; }
        public string? CodigoDenominacionBaseDato { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
