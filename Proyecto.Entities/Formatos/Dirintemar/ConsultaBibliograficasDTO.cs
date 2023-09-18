using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class ConsultaBibliograficasDTO
    {
        public int ConsultaBibliograficaId { get; set; }
        public string? FechaConsultaBibliografica { get; set; }
        public int? LibroPrestadoConsultaB { get; set; }
        public int? PublicacionePrestadaConsultaB { get; set; }
        public int? RevistaPrestada { get; set; }
        public int? FolletoPrestado { get; set; }
        public int? LecturaInterna { get; set; }
        public int? ReferenciaBibliografica { get; set; }
        public int? BusquedaEnSistema { get; set; }
        public int? TotalConsultaBibliografica { get; set; }
        public int? UsuariosLectoresConsultasB { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
