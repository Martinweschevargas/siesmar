using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class UsoPaginaWebInstitucionalDTO
    {

        public int? UsoPaginaWebInstitucionalId { get; set; }
        public string? CodigoTipoInformacion { get; set; }
        public int? NumeroPublicaciones { get; set; }
        public string? FechaPublicacion { get; set; }

        public string? DescTipoInformacion { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
