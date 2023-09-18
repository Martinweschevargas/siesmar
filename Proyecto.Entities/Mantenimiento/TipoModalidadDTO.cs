using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoModalidadDTO
    {
        public int TipoModalidadId { get; set; }
        public string? DescTipoModalidad { get; set; }
        public string? CodigoTipoModalidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
