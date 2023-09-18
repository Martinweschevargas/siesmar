using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dincydet
{
    public partial class ArchivoPublicaSuscripRevistasDTO
    {
        public int ArchivoPublicaSuscripRevistaId { get; set; }
        public string? NombreArticuloRevista { get; set; }
        public string? TipoArticuloRevista { get; set; }
        public string? CodigoAreaCT { get; set; }
        public string? DescAreaCT { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
