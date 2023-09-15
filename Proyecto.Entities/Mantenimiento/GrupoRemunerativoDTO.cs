using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoRemunerativoDTO
    {
        public int GrupoRemunerativoId { get; set; }
        public string? DescGrupoRemunerativo { get; set; }
        public string? CodigoGrupoRemunerativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
