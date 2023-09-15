using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EstablecimientoSaludMGPDTO
    {
        public int EstablecimientoSaludMGPId { get; set; }
        public String? CodigoEstablecimientoRENAES { get; set; }
        public String? CodigoRenaesMindef { get; set; }
        public int EntidadMilitarId { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? DescEstablecimientoSalud { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
