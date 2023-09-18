using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoVisitaGeneralDTO
    {
        public int TipoVisitaGeneralId { get; set; }
        public string? DescTipoVisitaGeneral { get; set; }
        public string? CodigoTipoVisitaGeneral { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
