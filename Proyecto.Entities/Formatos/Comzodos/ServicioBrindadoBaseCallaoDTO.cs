using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzodos
{
    public partial class ServicioBrindadoBaseCallaoDTO
    {

        public int ServicioBrindadoBaseCallaoId { get; set; }
        public string? FechaServicio { get; set; }
        public string? EmpresaReceptoraServicio { get; set; }
        public string? CodigoServicioBrindado { get; set; }
        public string? TiempoEmpleado { get; set; }

        public int? CargaId { get; set; }
        public string? DescServicioBrindado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}