using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CombustibleEspecificacionDTO
    {
        public int CombustibleEspecificacionId { get; set; }
        public string? DescCombustibleEspecificacion { get; set; }
        public string? CodigoCombustibleEspecificacion { get; set; }
        public int ClaseCombustibleId { get; set; }
        public string? DescClaseCombustible { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
