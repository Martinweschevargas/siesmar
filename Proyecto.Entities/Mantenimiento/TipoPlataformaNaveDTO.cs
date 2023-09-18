using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPlataformaNaveDTO
    {
        public int TipoPlataformaNaveId { get; set; }
        public string? DescTipoPlataformaNave { get; set; }
        public string? CodigoTipoPlataformaNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
