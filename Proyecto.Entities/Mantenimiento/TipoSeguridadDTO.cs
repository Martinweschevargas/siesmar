using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoSeguridadDTO
    {
        public int TipoSeguridadId { get; set; }
        public string? DescTipoSeguridad { get; set; }
        public string? CodigoTipoSeguridad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
