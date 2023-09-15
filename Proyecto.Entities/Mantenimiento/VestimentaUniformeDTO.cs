using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class VestimentaUniformeDTO
    {
        public int VestimentaUniformeId { get; set; }
        public string? DescVestimentaUniforme { get; set; }
        public string? CodigoVestimentaUniforme { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
