using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresna
{
    public partial class EgresoPromocionesDiresnaDTO
    {

        public int? EgresoPromocionId { get; set; }
        public string? DNIEgresado { get; set; }
        public string? SexoEgresado { get; set; }
        public string? FechaResolIngreso { get; set; }
        public string? FechaResolEgreso { get; set; }
        public string? ConcursoAdminisionIngreso { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
