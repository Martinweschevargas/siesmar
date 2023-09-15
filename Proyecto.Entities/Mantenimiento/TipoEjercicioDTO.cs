using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoEjercicioDTO
    {
        public int TipoEjercicioId { get; set; }
        public string? DescTipoEjercicio { get; set; }
        public string? CodigoTipoEjercicio { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
