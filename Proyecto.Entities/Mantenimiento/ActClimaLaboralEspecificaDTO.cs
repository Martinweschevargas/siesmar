using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ActClimaLaboralEspecificaDTO
    {
        public int ActClimaLaboralEspecificaId { get; set; }
        public string? DescActClimaLaboralEspecifica { get; set; }
        public int ActClimaLaboralGeneralId { get; set; }
        public string? DescActClimaLaboralGeneral { get; set; }
        public string? CodigoActClimaLaboralEspecifica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
