using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MarcaDTO
    {
        public int MarcaId { get; set; }
        public string? DescMarca { get; set; }
        public string? CodigoMarca { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
