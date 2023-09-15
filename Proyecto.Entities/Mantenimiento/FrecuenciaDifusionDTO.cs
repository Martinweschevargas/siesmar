using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FrecuenciaDifusionDTO
    {
        public int FrecuenciaDifusionId { get; set; }
        public string? DescFrecuenciaDifusion { get; set; }
        public string? CodigoFrecuenciaDifusion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
