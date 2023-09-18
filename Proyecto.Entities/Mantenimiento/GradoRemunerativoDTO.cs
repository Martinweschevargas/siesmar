using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GradoRemunerativoDTO
    {
        public int GradoRemunerativoId { get; set; }
        public string? DescGradoRemunerativo { get; set; }
        public string? CodigoGradoRemunerativo { get; set; }
        public int GradoRemunerativoGrupoId { get; set; }
        public string? DescGradoRemunerativoGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
