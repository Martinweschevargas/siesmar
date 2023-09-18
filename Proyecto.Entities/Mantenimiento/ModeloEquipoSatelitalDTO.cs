using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModeloEquipoSatelitalDTO
    {
        public int ModeloEquipoSatelitalId { get; set; }
        public string? DescModeloEquipoSatelital { get; set; }
        public string? CodigoModeloEquipoSatelital { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
