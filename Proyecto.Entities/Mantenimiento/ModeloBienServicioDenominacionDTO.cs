using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModeloBienServicioDenominacionDTO
    {
        public int ModeloBienServicioDenominacionId { get; set; }
        public string? DescModeloBienServicioDenominacion { get; set; }
        public string? CodigoModeloBienServicioDenominacion { get; set; }
        public int ModeloBienServicioSubcampoId { get; set; }
        public string? DescModeloBienServicioSubcampo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
