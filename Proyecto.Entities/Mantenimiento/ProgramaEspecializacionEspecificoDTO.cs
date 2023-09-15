using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProgramaEspecializacionEspecificoDTO
    {
        public int ProgramaEspecializacionEspecificoId { get; set; }
        public string? DescProgramaEspecializacionEspecifico { get; set; }
        public string? CodigoProgramaEspecializacionEspecifico { get; set; }
        public int ProgramaEspecializacionGrupoId { get; set; }
        public string? DescProgramaEspecializacionGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
