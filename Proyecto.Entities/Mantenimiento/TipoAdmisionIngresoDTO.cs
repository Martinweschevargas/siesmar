using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAdmisionIngresoDTO
    {
        public int TipoAdmisionIngresoId { get; set; }
        public string? DescTipoAdmisionIngreso { get; set; }
        public string? CodigoTipoAdmisionIngreso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
