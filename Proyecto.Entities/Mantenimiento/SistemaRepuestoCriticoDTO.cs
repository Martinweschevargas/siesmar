using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SistemaRepuestoCriticoDTO
    {
        public int SistemaRepuestoCriticoId { get; set; }
        public string? DescSistemaRepuestoCritico { get; set; }
        public string? CodigoSistemaRepuestoCritico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
