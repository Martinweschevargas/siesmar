using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class AlquilerAreaCentroEsparcimientoDTO
    {

        public int? AlquilerAreaCentroEsparcimientoId { get; set; }
        public string? FechaAlquiler { get; set; }
        public string? DNIUsuario { get; set; }
        public string? CodigoUsuarioAlquilerCentroEsparcimiento { get; set; }
        public string? CodigoClubEsparcimiento { get; set; }
        public string? CodigoAreaSalonClubEsparcimiento { get; set; }
        public string? CodigoTipoEvento { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraTermino { get; set; }
        public int? NumeroHoras { get; set; }
        public int? NumeroInvitados { get; set; }
        public decimal? MontoFacturado { get; set; }
        public int? CargaId { get; set; }
        public string? DescUsuarioAlquilerCentroEsparcimiento { get; set; }
        public string? DescClubEsparcimiento { get; set; }
        public string? DescAreaSalonClubEsparcimiento { get; set; }
        public string? DescTipoEvento { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
