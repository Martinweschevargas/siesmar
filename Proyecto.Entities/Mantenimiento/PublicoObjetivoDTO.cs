using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PublicoObjetivoDTO
    {
        public int PublicoObjetivoId { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
