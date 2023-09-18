using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionCursoDTO
    {
        public int ClasificacionCursoId { get; set; }
        public string? DescClasificacionCurso { get; set; }
        public string? CodigoClasificacionCurso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
