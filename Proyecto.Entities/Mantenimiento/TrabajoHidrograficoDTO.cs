using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TrabajoHidrograficoDTO
    {
        public int TrabajoHidrograficoId { get; set; }
        public string? DescTrabajoHidrografico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
