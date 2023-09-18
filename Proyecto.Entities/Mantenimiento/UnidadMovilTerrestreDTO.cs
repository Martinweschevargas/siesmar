using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UnidadMovilTerrestreDTO
    {
        public int UnidadMovilTerrestreId { get; set; }
        public string? PlacaUnidadMovilTerrestre { get; set; }
        public int? MarcaVehiculoId { get; set; }
        public string? ClasificacionVehiculo { get; set; }
        public int TipoVehiculoMovilId { get; set; }
        public string? DescTipoVehiculoMovil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
