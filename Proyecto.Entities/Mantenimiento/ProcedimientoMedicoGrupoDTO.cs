using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProcedimientoMedicoGrupoDTO
    {
        public int ProcedimientoMedicoGrupoId { get; set; }
        public string? DescProcedimientoMedicoGrupo { get; set; }
        public string? CodigoProcedimientoMedicoGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
