using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SubsistemaCombustibleLubricanteDTO
    {
        public int SubsistemaCombustibleLubricanteId { get; set; }
        public string? DescSubsistemaCombustibleLubricante { get; set; }
        public string? CodigoSubsistemaCombustibleLubricante { get; set; }
        public string? CodigoSistemaCombustibleLubricante { get; set; }
        public string? DescSistemaCombustibleLubricante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
