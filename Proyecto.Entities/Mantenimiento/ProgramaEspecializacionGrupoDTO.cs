using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProgramaEspecializacionGrupoDTO
    {
        public int ProgramaEspecializacionGrupoId { get; set; }
        public string? DescProgramaEspecializacionGrupo { get; set; }
        public string? CodigoProgramaEspecializacionGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
