using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AfeccionDTO
    {
        public int AfeccionId { get; set; }
        public string? DescAfeccion { get; set; }
        public string? CodigoAfeccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
