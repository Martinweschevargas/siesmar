using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PlataformaMedioComunicacionDTO
    {
        public int PlataformaMedioComunicacionId { get; set; }
        public string? DescPlataformaMedioComunicacion { get; set; }
        public string? CodigoPlataformaMedioComunicacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
