using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class ServicioFunerarioDTO
    {

        public int? ServicioFunerarioId { get; set; }
        public string? FechaServicioFunerario { get; set; }
        public string? DNISolicitante { get; set; }
        public string? CodigoPersonalSolicitante { get; set; }
        public string? CodigoCondicionSolicitante { get; set; }
        public string? CodigoPersonalBeneficiado { get; set; }
        public string? CodigoCategoriaPago { get; set; }
        public string? ServicioTramiteSepelio { get; set; }
        public string? ServicioAlquilerAtaud { get; set; }
        public string? ServicioVentaAtaud { get; set; }
        public string? ServicioCremacion { get; set; }
        public string? ServicioSalonVelatorio { get; set; }
        public string? ServicioCapillaArdiente { get; set; }
        public string? ServicioAlquilerCarroza { get; set; }
        public string? ServicioAlquilerCarroServicio { get; set; }
        public string? ServicioAlquilerCarroFlores { get; set; }
        public decimal? MontoTotalServicio { get; set; }


        public string? DescPersonalSolicitante { get; set; }
        public string? DescCondicionSolicitante { get; set; }
        public string? DescPersonalBeneficiado { get; set; }
        public string? DescCategoriaPago { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
