using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoDependenciaSuministroDTO
    {
        public int TipoDependenciaSuministroId { get; set; }
        public string? DescTipoDependenciaSuministro { get; set; }
        public string? CodigoTipoDependenciaSuministro { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
