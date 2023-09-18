using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TrabajoOceanograficoDTO
    {
        public int TrabajoOceanograficoId { get; set; }
        public string? DescTrabajoOceanografico { get; set; }
        public string? CodigoTrabajoOceanografico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
