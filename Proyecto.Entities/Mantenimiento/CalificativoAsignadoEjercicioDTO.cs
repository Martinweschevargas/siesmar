using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CalificativoAsignadoEjercicioDTO
    {
        public int CalificativoAsignadoEjercicioId { get; set; }
        public string? Descripcion { get; set; }
        public string? CodigoCalificativoAsignadoEjercicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
