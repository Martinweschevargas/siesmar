using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecialidadPersonalDTO
    {
        public int EspecialidadPersonalId { get; set; }
        public string? DescEspecialidadPersonal { get; set; }
        public string? CodigoEspecialidadPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
