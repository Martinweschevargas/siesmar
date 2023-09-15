using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProcedimientoMedicoSubseccionDTO
    {
        public int ProcedimientoMedicoSubseccionId { get; set; }
        public string? DescProcedimientoMedicoSubseccion { get; set; }
        public string? CodigoProcedimientoMedicoSubseccion { get; set; }
        public int ProcedimientoMedicoSeccionId { get; set; }
        public string? DescProcedimientoMedicoSeccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
