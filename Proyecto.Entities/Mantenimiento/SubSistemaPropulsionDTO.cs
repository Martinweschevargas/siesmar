using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SubSistemaPropulsionDTO
    {
        public int SubSistemaPropulsionId { get; set; }
        public string? DescSubSistemaPropulsion { get; set; }
        public string? CodigoSubSistemaPropulsion { get; set; }
        public string? CodigoSistemaPropulsion { get; set; }
        public string? DescSistemaPropulsion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
