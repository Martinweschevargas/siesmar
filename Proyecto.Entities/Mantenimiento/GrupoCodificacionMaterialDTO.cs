using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoCodificacionMaterialDTO
    {
        public int GrupoCodificacionMaterialId { get; set; }
        public string? DescGrupoCodificacionMaterial { get; set; }
        public string? CodigoGrupoCodificacionMaterial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
