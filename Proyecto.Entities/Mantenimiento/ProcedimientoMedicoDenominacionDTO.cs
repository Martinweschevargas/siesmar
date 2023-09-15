using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProcedimientoMedicoDenominacionDTO
    {
        public int ProcedimientoMedicoDenominacionId { get; set; }
        public string? DescProcedimientoMedicoDenominacion { get; set; }
        public string? CodigoProcedimientoMedicoDenominacion { get; set; }
        public int ProcedimientoMedicoSubseccionId { get; set; }
        public string? DescProcedimientoMedicoSubseccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
