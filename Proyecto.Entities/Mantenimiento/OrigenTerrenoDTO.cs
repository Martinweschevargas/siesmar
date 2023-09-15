using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class OrigenTerrenoDTO
    {
        public int OrigenTerrenoId { get; set; }
        public string? DescOrigenTerreno { get; set; }
        public string? CodigoOrigenTerreno { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
