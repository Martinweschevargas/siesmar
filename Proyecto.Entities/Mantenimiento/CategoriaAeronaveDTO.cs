using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CategoriaAeronaveDTO
    {
        public int CategoriaAeronaveId { get; set; }
        public string? DescCategoriaAeronave { get; set; }
        public string? CodigoCategoriaAeronave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
