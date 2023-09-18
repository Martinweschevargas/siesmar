using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ServicioBrindadoDTO
    {
        public int ServicioBrindadoId { get; set; }
        public string? DescServicioBrindado { get; set; }
        public string? CodigoServicioBrindado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
