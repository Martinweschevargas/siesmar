using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAsignacionCasaServicioDTO
    {
        public int TipoAsignacionCasaServicioId { get; set; }
        public string? DescTipoAsignacionCasaServicio { get; set; }
        public string? CodigoTipoAsignacionCasaServicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
