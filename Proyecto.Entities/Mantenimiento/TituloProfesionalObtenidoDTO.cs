using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TituloProfesionalObtenidoDTO
    {
        public int TituloProfesionalObtenidoId { get; set; }
        public string? DescTituloProfesionalObtenido { get; set; }
        public string? CodigoTituloProfesionalObtenido { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
