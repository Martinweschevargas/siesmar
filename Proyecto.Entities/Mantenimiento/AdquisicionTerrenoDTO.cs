using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AdquisicionTerrenoDTO
    {
        public int AdquisicionTerrenoId { get; set; }
        public string? DescAdquisicionTerreno { get; set; }
        public string? CodigoAdquisicionTerreno { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
