using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoRepuestoCriticoDTO
    {
        public int AlistamientoRepuestoCriticoId { get; set; }
        public string? CodigoAlistamientoRepuestoCritico { get; set; }
        public string? CodigoSistemaRepuestoCritico { get; set; }
        public string? CodigoSubsistemaRepuestoCritico { get; set; }
        public string? Equipo { get; set; }
        public string? Repuesto { get; set; }
        public string? Existente { get; set; }
        public string? Necesario { get; set; }
        public string? CoeficientePonderacion { get; set; }

        public string? DescSubsistemaRepuestoCritico { get; set; }
        public string? DescSistemaRepuestoCritico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
