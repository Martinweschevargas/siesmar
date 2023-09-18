using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PublicidadEsnaDTO
    {
        public int PublicidadEsnaId { get; set; }
        public string? DescPublicidadEsna { get; set; }
        public string? CodigoPublicidadEsna { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
