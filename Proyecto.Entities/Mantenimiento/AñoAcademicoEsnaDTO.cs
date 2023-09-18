using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AñoAcademicoEsnaDTO
    {
        public int AñoAcademicoEsnaId { get; set; }
        public string? DescAñoAcademicoEsna { get; set; }
        public string? CodigoAñoAcademicoEsna { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
