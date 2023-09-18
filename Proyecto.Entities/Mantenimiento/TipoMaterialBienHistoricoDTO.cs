using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoMaterialBienHistoricoDTO
    {
        public int TipoMaterialBienHistoricoId { get; set; }
        public string? DescTipoMaterialBienHistorico { get; set; }
        public string? CodigoTipoMaterialBienHistorico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
