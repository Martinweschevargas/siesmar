using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoUnidadNavalInterventoraDTO
    {
        public int TipoUnidadNavalInterventoraId { get; set; }
        public string? DescTipoUnidadNavalInterventora { get; set; }
        public string? CodigoTipoUnidadNavalInterventora { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
