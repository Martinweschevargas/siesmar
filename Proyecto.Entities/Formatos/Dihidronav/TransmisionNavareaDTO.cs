using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class TransmisionNavareaDTO
    {

        public int? TransmisionNavareaId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? NumeroNavarea { get; set; }
        public string? RadioavisoNautico { get; set; }
        public string? FechaEmision { get; set; }
        public string? Promotor { get; set; }
        public string? FechaTermino { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}