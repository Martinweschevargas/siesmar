using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FrecuenciaDTO
    {
        public int FrecuenciaId { get; set; }
        public string? DescFrecuencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
