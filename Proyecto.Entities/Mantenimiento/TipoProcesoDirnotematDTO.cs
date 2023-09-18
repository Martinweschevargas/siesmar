using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoProcesoDirnotematDTO
    {
        public int TipoProcesoDirnotematId { get; set; }
        public string? DescTipoProcesoDirnotemat { get; set; }
        public string? CodigoTipoProcesoDirnotemat { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
