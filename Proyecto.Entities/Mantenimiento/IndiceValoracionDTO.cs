using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class IndiceValoracionDTO
    {
        public int IndiceValoracionId { get; set; }
        public string? DescIndiceValoracion { get; set; }
        public string? Criterio { get; set; }
        public int CodigoDependencia { get; set; }
        public char SI { get; set; }
        public char NO { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }

}
