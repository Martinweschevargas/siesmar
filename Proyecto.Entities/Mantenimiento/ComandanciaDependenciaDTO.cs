using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ComandanciaDependenciaDTO
    {
        public int ComandanciaDependenciaId { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
