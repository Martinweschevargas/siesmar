using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EmpresaProveedoraDTO
    {
        public int EmpresaProveedoraId { get; set; }
        public string? DescEmpresaProveedora { get; set; }
        public string? CodigoEmpresaProveedora { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
