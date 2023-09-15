using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoLubricanteDTO
    {
        public int TipoLubricanteId { get; set; }
        public string? DescTipoLubricante { get; set; }
        public string? CodigoTipoLubricante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
