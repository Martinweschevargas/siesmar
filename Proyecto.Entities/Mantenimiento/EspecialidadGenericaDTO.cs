using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecialidadGenericaDTO
    {
        public int EspecialidadGenericaId { get; set; }
        public string? DescEspecialidadGenerica { get; set; }
        public string? CodigoEspecialidadGenerica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
