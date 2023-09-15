using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class UsoRedSocialInstitucionDTO
    {

        public int? UsoRedSocialInstitucionId { get; set; }
        public string? CodigoRedSocial { get; set; }
        public string? FechaEmision { get; set; }
        public int? NumeroSeguidores { get; set; }
        public int? IncrementoSeguidores { get; set; }
        public string? TemaMasComentado { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }
        public int? NumeroPublicaciones { get; set; }
        public int? TotalSeguidoresCreacion { get; set; }


        public string? DescRedSocial { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
