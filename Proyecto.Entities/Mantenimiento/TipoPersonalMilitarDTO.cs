using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPersonalMilitarDTO
    {
        public int TipoPersonalMilitarId { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
