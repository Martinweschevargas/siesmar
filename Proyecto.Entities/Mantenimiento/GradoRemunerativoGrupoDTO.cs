using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GradoRemunerativoGrupoDTO
    {
        public int GradoRemunerativoGrupoId { get; set; }
        public string? DescGradoRemunerativoGrupo { get; set; }
        public int GrupoRemunerativoId { get; set; }
        public string? DescGrupoRemunerativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
