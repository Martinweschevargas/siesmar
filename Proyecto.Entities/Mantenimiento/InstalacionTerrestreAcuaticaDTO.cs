using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InstalacionTerrestreAcuaticaDTO
    {
        public int InstalacionTerrestreAcuaticaId { get; set; }
        public string? DescInstalacionTerrestreAcuatica { get; set; }
        public string? CodigoInstalacionTerrestreAcuatica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
