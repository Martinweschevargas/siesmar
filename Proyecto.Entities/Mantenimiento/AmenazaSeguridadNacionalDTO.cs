using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AmenazaSeguridadNacionalDTO
    {
        public int AmenazaSeguridadNacionalId { get; set; }
        public string? DescAmenazaSeguridadNacional { get; set; }
        public string? CodigoAmenazaSeguridadNacional { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
