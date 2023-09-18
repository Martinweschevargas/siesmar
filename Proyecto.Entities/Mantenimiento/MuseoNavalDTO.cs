using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MuseoNavalDTO
    {
        public int MuseoNavalId { get; set; }
        public string? DescMuseoNaval { get; set; }
        public string? CodigoMuseoNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
