using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionLaboralDTO
    {
        public int CondicionLaboralId { get; set; }
        public string? DescCondicionLaboral { get; set; }
        public string? CodigoCondicionLaboral { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
