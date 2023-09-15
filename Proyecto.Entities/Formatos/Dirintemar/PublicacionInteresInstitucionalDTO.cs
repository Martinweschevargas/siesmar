using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class PublicacionInteresInstitucionalDTO
    {
        public int PublicacionInteresInstitucionalId { get; set; }
        public int? TipoPublicacionId { get; set; }
        public string? DenominacionTemaPublicacion { get; set; }
        public string? NroPublicacion { get; set; }
        public string? FechaPublicacion { get; set; }
        public int? NumeroEjemplaresPublicados { get; set; }
        public int? NroSuscriptores { get; set; }
        public string? PromotorPublicaciones { get; set; }
        public string? ResponsablePublicacion { get; set; }
        public decimal InversionPublicacion { get; set; }
        public string? DescTipoPublicacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
