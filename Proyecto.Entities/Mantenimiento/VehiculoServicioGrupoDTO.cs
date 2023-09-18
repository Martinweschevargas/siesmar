using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class VehiculoServicioGrupoDTO
    {
        public int VehiculoServicioGrupoId { get; set; }
        public string? DescVehiculoServicioGrupo { get; set; }
        public string? CodigoVehiculoServicioGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
