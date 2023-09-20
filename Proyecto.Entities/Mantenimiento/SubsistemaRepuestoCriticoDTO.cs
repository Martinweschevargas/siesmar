using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SubsistemaRepuestoCriticoDTO
    {
        public int SubsistemaRepuestoCriticoId { get; set; }
        public string? CodigoSubsistemaRepuestoCritico { get; set; }
        public string? DescSubsistemaRepuestoCritico { get; set; }
        public string? CodigoSistemaRepuestoCritico { get; set; }
        public string? DescSistemaRepuestoCritico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
