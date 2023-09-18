using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModeloBienServicioSubcampoDTO
    {
        public int ModeloBienServicioSubcampoId { get; set; }
        public string? DescModeloBienServicioSubcampo { get; set; }
        public string? CodigoModeloBienServicioSubcampo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
