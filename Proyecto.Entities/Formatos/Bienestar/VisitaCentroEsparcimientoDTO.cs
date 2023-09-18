using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class VisitaCentroEsparcimientoDTO
    {
        public int? VisitaCentroEsparcimientoId { get; set; }
        public string? FechaVisitaCentro { get; set; }
        public string? DNIUsuario { get; set; }
        public string? CodigoUsuarioCentroEsparcimiento { get; set; }
        public string? CodigoClubEsparcimiento { get; set; }
        public int? NumeroHoras { get; set; }
        public int? NumeroInvitados { get; set; }
        public decimal? MontoFacturado { get; set; }


        public string? DescUsuarioCentroEsparcimiento { get; set; }
        public string? DescClubEsparcimiento { get; set; }
        public int? CargaId { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public string? Mes { get; set; }
        public string? CentroEsparcimiento { get; set; }
        public string? TipoUsuario { get; set; }
        public string? Visitas { get; set; }

    }
}
