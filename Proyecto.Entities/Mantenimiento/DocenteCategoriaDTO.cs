using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DocenteCategoriaDTO
    {
        public int DocenteCategoriaId { get; set; }
        public string? DescDocenteCategoria { get; set; }
        public string? CodigoDocenteCategoria { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
