using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DireccionTecnicaDTO
    {
        public int DireccionTecnicaId { get; set; }
        public string? DescDireccionTecnica { get; set; }
        public string? CodigoDireccionTecnica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
