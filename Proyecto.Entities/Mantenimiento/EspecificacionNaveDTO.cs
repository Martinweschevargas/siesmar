using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecificacionNaveDTO
    {
        public int EspecificacionNaveId { get; set; }
        public string? DescEspecificacionNave { get; set; }
        public string? CodigoEspecificacionNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
