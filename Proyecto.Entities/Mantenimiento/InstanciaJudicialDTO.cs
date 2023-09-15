using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InstanciaJudicialDTO
    {
        public int InstanciaJudicialId { get; set; }
        public string? DescInstanciaJudicial { get; set; }
        public string? CodigoInstanciaJudicial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
