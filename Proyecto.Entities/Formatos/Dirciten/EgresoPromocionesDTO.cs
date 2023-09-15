using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirciten
{
    public partial class EgresoPromocionesDTO
    {
        public int EgresoPromocionId { get; set; }
        public string? DNIEgresoPromocion { get; set; }
        public string? GeneroEgresoPromocion{ get; set; }
        public string? FechaResolIngreso { get; set; }
        public string? FechaResolEgreso { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
