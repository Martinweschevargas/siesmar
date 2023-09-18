using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoMunicionDTO
    {
        public int AlistamientoMunicionId { get; set; }
        public string? CodigoAlistamientoMunicion { get; set; }
        public string? CodigoSistemaMunicion { get; set; }
        public string? CodigoSubsistemaMunicion { get; set; }
        public string? Equipo { get; set; }
        public string? Municion { get; set; }
        public string? Existente { get; set; }
        public int Necesaria { get; set; }
        public int CoeficientePonderacion { get; set; }

        public string? DescSistemaMunicion { get; set; }
        public string? DescSubsistemaMunicion { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
