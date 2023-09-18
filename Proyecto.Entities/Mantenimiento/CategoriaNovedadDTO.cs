using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CategoriaNovedadDTO
    {
        public int CategoriaNovedadId { get; set; }
        public string? DescCategoriaNovedad { get; set; }
        public string? CodigoCategoriaNovedad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
