using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoEstudioContraInteligenciaDTO
    {
        public int TipoEstudioContrainteligenciaId { get; set; }
        public string? DescTipoEstudioContrainteligencia { get; set; }
        public string? CodigoTipoEstudioContrainteligencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
