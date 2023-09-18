using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CapitaniaDTO
    {
        public int? CapitaniaId { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescCapitania { get; set; }
        public string? CodigoCapitania { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public string? JefaturaDistritoCapitaniaDesc { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
