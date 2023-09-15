using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class VehiculoServicioTipoDTO
    {
        public int VehiculoServicioTipoId { get; set; }
        public string? DescVehiculoServicioTipo { get; set; }
        public string? CodigoVehiculoServicioTipo { get; set; }
        public int VehiculoServicioGrupoId { get; set; }
        public string? DescVehiculoServicioGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
