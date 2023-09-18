using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class NivelEstudioDTO
    {
        public int NivelEstudioId { get; set; }
        public string? DescNivelEstudio { get; set; }
        public string? CodigoNivelEstudio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
