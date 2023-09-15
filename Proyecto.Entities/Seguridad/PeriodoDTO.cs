using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Seguridad
{
    public class PeriodoDTO
    {
        public int PeriodoId { get; set; }
        public string? Nombre { get; set; }

  

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
