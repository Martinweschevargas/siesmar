using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProcedimientoMedicoSeccionDTO
    {
        public int ProcedimientoMedicoSeccionId { get; set; }
        public string? DescProcedimientoMedicoSeccion { get; set; }
        public string? CodigoProcedimientoMedicoSeccion { get; set; }
        public int ProcedimientoMedicoGrupoId { get; set; }
        public string? DescProcedimientoMedicoGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
