using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoSeleccionDTO
    {
        public int TipoSeleccionId { get; set; }
        public string? DescTipoSeleccion { get; set; }
        public string? CodigoTipoSeleccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
