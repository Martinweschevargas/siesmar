using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MaterialRepBienHistoricoDTO
    {
        public int MaterialRepBienHistoricoId { get; set; }
        public string? DescMaterialRepBienHistorico { get; set; }
        public string? CodigoMaterialRepBienHistorico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
