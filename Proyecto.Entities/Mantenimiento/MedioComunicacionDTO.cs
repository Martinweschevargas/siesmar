using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MedioComunicacionDTO
    {
        public int MedioComunicacionId { get; set; }
        public string? DescMedioComunicacion { get; set; }
        public string? CodigoMedioComunicacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
