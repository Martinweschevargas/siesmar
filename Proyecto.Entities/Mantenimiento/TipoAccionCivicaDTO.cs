using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAccionCivicaDTO
    {
        public int TipoAccionCivicaId { get; set; }
        public string? DescTipoAccionCivica { get; set; }
        public string? CodigoTipoAccionCivica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
