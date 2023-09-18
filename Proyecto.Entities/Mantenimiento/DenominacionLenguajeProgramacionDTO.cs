using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DenominacionLenguajeProgramacionDTO
    {
        public int DenominacionLenguajeProgramacionId { get; set; }
        public string? DescDenominacionLenguajeProgramacion { get; set; }
        public string? CodigoDenominacionLenguajeProgramacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
