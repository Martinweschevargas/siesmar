using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoVehiculoMovilDTO
    {
        public int TipoVehiculoMovilId { get; set; }
        public string? DescTipoVehiculoMovil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
