using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SituacionPersonalNavalDTO
    {
        public int SituacionPersonalNavalId { get; set; }
        public string? DescSituacionPersonalNaval { get; set; }
        public string? CodigoSituacionPersonalNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
