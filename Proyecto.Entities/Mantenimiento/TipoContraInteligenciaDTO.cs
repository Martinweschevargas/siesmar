using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoContraInteligenciaDTO
    {
        public int TipoContrainteligenciaId { get; set; }
        public string? DescTipoContrainteligencia { get; set; }
        public string? CodigoTipoContrainteligencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
