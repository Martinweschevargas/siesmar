using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModalidadIngresoEsnaDTO
    {
        public int ModalidadIngresoEsnaId { get; set; }
        public string? DescModalidadIngresoEsna { get; set; }
        public string? CodigoModalidadIngresoEsna { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
