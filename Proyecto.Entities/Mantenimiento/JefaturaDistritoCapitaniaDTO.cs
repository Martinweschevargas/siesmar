using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class JefaturaDistritoCapitaniaDTO
    {
        public int JefaturaDistritoCapitaniaId { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
