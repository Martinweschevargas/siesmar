using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ComandanciaNavalDTO
    {
        public int ComandanciaNavalId { get; set; }
        public string? DescComandanciaNaval { get; set; }
        public string? CodigoComandanciaNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
