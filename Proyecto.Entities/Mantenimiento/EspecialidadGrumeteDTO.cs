using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EspecialidadGrumeteDTO
    {
        public int EspecialidadGrumeteId { get; set; }
        public string? DescEspecialidadGrumete { get; set; }
        public string? CodigoEspecialidadGrumete { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
