using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoCompetenciaTecnicaDTO
    {
        public int TipoCompetenciaTecnicaId { get; set; }
        public string? DescTipoCompetenciaTecnica { get; set; }
        public string? CodigoTipoCompetenciaTecnica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
