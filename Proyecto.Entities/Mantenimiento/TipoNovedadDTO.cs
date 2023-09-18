using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoNovedadDTO
    {
        public int TipoNovedadId { get; set; }
        public string? DescTipoNovedad { get; set; }
        public string? CodigoTipoNovedad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
