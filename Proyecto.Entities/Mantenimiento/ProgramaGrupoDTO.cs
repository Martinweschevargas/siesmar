using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProgramaGrupoDTO
    {
        public int ProgramaGrupoId { get; set; }
        public string? DescProgramaGrupo { get; set; }
        public string? CodigoProgramaGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
