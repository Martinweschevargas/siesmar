using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MedidaAdaptadaDisposicionFinalDTO
    {
        public int MedidaAdaptadaDisposicionFinalId { get; set; }
        public string? DescMedidaAdaptadaDisposicionFinal { get; set; }
        public string? CodigoMedidaAdaptadaDisposicionFinal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
