using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SubsistemaMunicionDTO
    {
        public int SubsistemaMunicionId { get; set; }
        public string? CodigoSubsistemaMunicion { get; set; }
        public string? DescSubsistemaMunicion { get; set; }
        public string? CodigoSistemaMunicion { get; set; }
        public string? DescSistemaMunicion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
