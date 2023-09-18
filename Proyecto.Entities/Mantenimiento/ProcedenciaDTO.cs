using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProcedenciaDTO
    {
        public int ProcedenciaId { get; set; }
        public string CodigoProcedencia { get; set; }
        public string? DescProcedencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
