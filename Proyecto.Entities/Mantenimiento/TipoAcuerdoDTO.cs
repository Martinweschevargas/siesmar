using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoAcuerdoDTO
    {
        public int TipoAcuerdoId { get; set; }
        public string? DescTipoAcuerdo { get; set; }
        public string? CodigoTipoAcuerdo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
