using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SistemaPropulsionDTO
    {
        public int SistemaPropulsionId { get; set; }
        public string? CodigoSistemaPropulsion { get; set; }
        public string? DescSistemaPropulsion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
