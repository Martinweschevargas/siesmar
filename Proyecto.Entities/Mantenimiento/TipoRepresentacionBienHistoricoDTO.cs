using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoRepresentacionBienHistoricoDTO
    {
        public int TipoRepresentacionBienHistoricoId { get; set; }
        public string? DescTipoRepresentacionBienHistorico { get; set; }
        public string? CodigoTipoRepresentacionBienHistorico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
